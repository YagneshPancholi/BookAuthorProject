import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/DataTypes';
import { AuthorService } from 'src/app/services/author/author.service';
import { BookService } from 'src/app/services/book/book.service';
import { GenreService } from 'src/app/services/genre/genre.service';
import { PublisherService } from 'src/app/services/publisher/publisher.service';

@Component({
  selector: 'Alt-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css'],
})
export class EditBookComponent {
  IsBookUpdated = false;
  FieldRequiredMessage = 'Field Is Required';
  UpdateBookMessage: string | undefined;
  currentBookName: string | null | undefined;
  currentBookData: Book | undefined;
  bookDataToUpdate: sendUpdateBookData | undefined;

  authors: Array<string> = [];
  public selectedAuthors: Array<string> = [];
  genres: Array<string> = [];
  public selectedGenres: Array<string> = [];
  publishers: Array<string> = [];
  public selectedPublishers: Array<string> = [];
  constructor(
    private router: Router,
    private bookService: BookService,
    private activatedRoute: ActivatedRoute,
    private genreService: GenreService,
    private authorService: AuthorService,
    private publisherService: PublisherService
  ) {}
  loadCurrentBookNameAndData() {
    this.currentBookName = this.activatedRoute.snapshot.paramMap.get('name');

    if (this.currentBookName) {
      this.bookService
        .getBookByName(this.currentBookName)
        .subscribe((result) => {
          this.currentBookData = result;
          this.selectedAuthors = result.authorNames;
          this.selectedGenres = result.genreNames;
          this.selectedPublishers = result.publisherNames;
        });
    }
  }
  ngOnInit() {
    this.loadCurrentBookNameAndData();
    this.genreService.getAllGenres().subscribe((result) => {
      result.forEach((element) => {
        this.genres.push(element.genreName);
      });
    });
    this.authorService.getAllAuthors().subscribe((result) => {
      result.forEach((element) => {
        this.authors.push(element.authorName);
      });
    });
    this.publisherService.getAllPublishers().subscribe((result) => {
      result.forEach((element) => {
        this.publishers.push(element.publisherName);
      });
    });
  }

  cancelUpdateBookForm() {
    this.router.navigate(['/Book']).then(() => {
      window.location.reload();
    });
  }
  removeFromSelectedArray(arr: Array<string>, id: number) {
    if (id == 1) {
      this.selectedAuthors = arr;
    }
    if (id == 2) {
      this.selectedGenres = arr;
    }
    if (id == 3) {
      this.selectedPublishers = arr;
    }
  }
  updateBook(request: Book) {
    console.error(request);
    if (this.currentBookName && request) {
      this.bookService
        .updateBook(this.currentBookName, request)
        .subscribe((result) => {
          if (result) {
            this.UpdateBookMessage = 'successfully Updated..';
            this.IsBookUpdated = true;
            setTimeout(() => {
              this.UpdateBookMessage = undefined;
              this.router.navigate(['/Book']).then(() => {
                window.location.reload();
              });
            }, 3000);
          } else {
            this.UpdateBookMessage = 'Update Book Failed';
            setTimeout(() => {
              this.UpdateBookMessage = undefined;
            }, 3000);
          }
        });
    }
  }
}
export interface sendUpdateBookData {
  bookName: string;
  price: number;
  authorName: string;
  genreName: string;
  publisherName: string;
}
