# Knowledge: How to Fix "Build Artifacts Being Tracked by Git"

## The Problem

When you create a .NET, WPF, or Angular project and commit it without a `.gitignore`, git tracks everything — including build output files like `bin/`, `obj/`, `.vs/` folders. These are generated automatically every time you build, so they:

- Pollute `git status` with hundreds of fake "changes"
- Bloat the repository with binary files that don't belong in source control
- Cause merge conflicts on files that should never be shared

**Simply adding a `.gitignore` later does NOT fix it.** Git continues tracking files it already knows about, even if they match a new ignore pattern. You have to explicitly tell git to stop tracking them.

---

## Root Cause Explained

Git has two concepts to understand:

| Concept                      | What it means                           |
| ---------------------------- | --------------------------------------- |
| **Working tree**             | Files on your actual disk               |
| **Git index (staging area)** | The snapshot git is aware of and tracks |

When you first committed without a `.gitignore`, git added every file — including `bin/`, `obj/` — into the index. Adding `.gitignore` afterwards only prevents **new** files from being added. Already-tracked files stay tracked forever, until you explicitly remove them from the index.

---

## The Fix: 3 Phases

### Phase 1 — Create the `.gitignore`

**Why:** Prevents any future build artifacts from ever being tracked again.

**What I created:** A single root `.gitignore` at the workspace root covering all three project types:

- `.NET / C#` → `[Bb]in/`, `[Oo]bj/`, `*.user`, `*.suo`
- `Visual Studio` → `.vs/`
- `Angular / Node` → `node_modules/`, `dist/`, `.angular/cache/`
- `OS` → `.DS_Store`, `Thumbs.db`

**Why bracket patterns like `[Bb]in/`?**  
Cross-platform safety. On case-sensitive systems (Linux, Mac), `bin/` and `Bin/` are different. The bracket pattern matches both regardless of OS.

**Verification command:**

```powershell
git check-ignore -v --no-index "BackEnd/Application/bin/Debug/net7.0/Application.dll"
```

- `--no-index` → test the pattern even if the file is already tracked
- Returns the matching `.gitignore` line if the pattern works, or nothing if it doesn't

---

### Phase 2 — Untrack Already-Committed Artifacts

**Why:** `.gitignore` doesn't retroactively untrack files. You must manually remove them from the index.

**The key command:**

```powershell
git rm --cached -r <path>
```

| Flag       | Meaning                                               |
| ---------- | ----------------------------------------------------- |
| `--cached` | Only remove from git's index. Do NOT delete from disk |
| `-r`       | Recursive — remove entire directories                 |

**This is safe.** Your files remain on disk. Only git's internal tracking record is changed.

**Before running `git rm`, I first checked what was actually tracked:**

```powershell
git ls-files
```

This lists every file git is currently tracking. I piped it through filters to find artifacts:

```powershell
git ls-files | Select-String "\.vs"       # find .vs/ files
git ls-files | Select-String "csproj.user" # find .csproj.user files
git ls-files --deleted                     # files tracked but missing from disk
```

**Interesting discovery:** The `bin/` and `obj/` folders were never actually committed (only 336 total tracked files, not 2,680). What git was showing as "modified" (`M`) in `git status` were deletions — files that had been tracked in an earlier commit but deleted from disk. The `.vs/` folders (38 files) and 2 `.csproj.user` files were the real tracked artifacts.

**Commands I ran:**

```powershell
git rm --cached -r "BackEnd/.vs/"
git rm --cached -r "BackEnd/Project1/.vs/"
git rm --cached -r "Project1WpfMVVM/.vs/"
git rm --cached "BackEnd/Project1/API.csproj.user"
git rm --cached "Project1WpfMVVM/Project1WpfMVVM.csproj.user"
```

**Verification after untracking:**

```powershell
# Should return 0 lines (nothing .vs-related tracked anymore)
git ls-files | Select-String "\.vs" | Measure-Object -Line

# Should return nothing
git ls-files | Select-String "csproj.user"

# Confirm disk files still exist
Test-Path "BackEnd/.vs"
Test-Path "BackEnd/Project1/API.csproj.user"
```

**Check staged changes before committing:**

```powershell
git diff --cached --name-only --diff-filter=D | Measure-Object -Line
git diff --cached --name-only --diff-filter=D | Select-Object -First 20
```

- `--cached` → look at what's staged (not yet committed)
- `--diff-filter=D` → only show Deletions

---

### Phase 3 — Commit the Cleanup

**Why:** All the `git rm --cached` changes are only staged. You must commit to make them permanent.

```powershell
git add .gitignore
git commit -m "chore: add .gitignore and remove build artifacts from tracking

- Add root .gitignore covering .NET, WPF, Angular, and VS tooling
- Untrack .vs/, *.csproj.user files
- Files remain on disk, only removed from git index"
```

**Note:** `git add .gitignore` is needed because the new `.gitignore` file itself is untracked and must be staged before committing.

---

## Key Commands Reference Card

| Command                                         | Purpose                                           |
| ----------------------------------------------- | ------------------------------------------------- |
| `git ls-files`                                  | List all files git is currently tracking          |
| `git ls-files --deleted`                        | Files tracked by git but missing from disk        |
| `git check-ignore -v --no-index <path>`         | Test if a path would be ignored by `.gitignore`   |
| `git rm --cached <file>`                        | Stop tracking a file (keep on disk)               |
| `git rm --cached -r <folder>`                   | Stop tracking a folder recursively (keep on disk) |
| `git diff --cached --name-only`                 | Show what's staged for the next commit            |
| `git diff --cached --name-only --diff-filter=D` | Show only staged deletions                        |
| `git status --short`                            | Quick view of working tree + staging area state   |

---

## The Mental Model

```
DISK (your files)          GIT INDEX (git's tracking)
─────────────────          ──────────────────────────
bin/                  ←──  bin/        ← git rm --cached -r removes from here
obj/                  ←──  obj/          but NOT from disk
.vs/                  ←──  .vs/
Program.cs            ←──  Program.cs  ← this stays tracked (source code)
```

After `git rm --cached -r bin/`:

```
DISK                       GIT INDEX
─────────────────          ──────────────────────────
bin/         (still here)  (bin/ no longer exists here)
.gitignore                 .gitignore  ← future bin/ builds are now ignored
Program.cs                 Program.cs
```

---

## What NOT To Do

| Bad Approach                            | Why It's Bad                                            |
| --------------------------------------- | ------------------------------------------------------- |
| `git rm -r bin/` (without `--cached`)   | Deletes files from disk too — breaks your build         |
| `git filter-branch` / `git filter-repo` | Rewrites entire git history — dangerous on shared repos |
| Deleting the `.git` folder and re-init  | Loses all history                                       |
| Ignoring the problem                    | Every `git status` and `git diff` becomes noise         |

---

## Lessons Learned

1. **Always create a `.gitignore` before your first commit.** GitHub offers pre-made `.gitignore` templates for every language when creating a new repo.

2. **`.gitignore` is not retroactive.** If you forgot it, you need `git rm --cached` to fix it.

3. **`git status` showing `M` (modified) on `bin/` files doesn't mean the build output is tracked.** It can mean those files were tracked in a previous commit and deleted from disk — git sees their absence as a "modification".

4. **`git ls-files` is your source of truth** for what's actually tracked, not `git status`.

5. **`--cached` is your safety net** — never run `git rm` without it unless you want files deleted from disk.
