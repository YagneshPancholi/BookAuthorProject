import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from 'src/app/DataTypes';
import { AuthorService } from 'src/app/services/author/author.service';

@Component({
  selector: 'Alt-edit-author',
  templateUrl: './edit-author.component.html',
  styleUrls: ['./edit-author.component.css'],
})
export class EditAuthorComponent {
  FieldRequiredMessage = 'Field Is Required';
  IsAuthorUpdated = false;
  UpdateAuthorMessage: string | undefined;
  currentAuthorName: string | null | undefined;
  currentAuthorData: Author | undefined;
  authorDataToUpdate: sendUpdateAuthorData | undefined;
  constructor(
    private router: Router,
    private authorService: AuthorService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.currentAuthorName = this.activatedRoute.snapshot.paramMap.get('name');
    if (this.currentAuthorName) {
      this.authorService
        .getAuthorByName(this.currentAuthorName)
        .subscribe((result) => {
          this.currentAuthorData = result;
        });
    }
  }

  cancelUpdateAuthorForm() {
    this.router.navigate(['/Author']).then(() => {
      window.location.reload();
    });
  }

  updateAuthor(request: Author) {
    if (this.currentAuthorName && request) {
      this.authorService
        .updateAuthor(this.currentAuthorName, request)
        .subscribe((result) => {
          if (result) {
            this.UpdateAuthorMessage = 'successfully Updated..';
            this.IsAuthorUpdated = true;
            setTimeout(() => {
              this.UpdateAuthorMessage = undefined;
              this.router.navigate(['/Author']).then(() => {
                window.location.reload();
              });
            }, 3000);
          } else {
            this.UpdateAuthorMessage = 'Update Author Failed';
            setTimeout(() => {
              this.UpdateAuthorMessage = undefined;
            }, 3000);
          }
        });
    }
  }
}
export interface sendUpdateAuthorData {
  authorName: string;
  birthDate: string;
  email: string;
  education: string;
  bookName: string;
}
