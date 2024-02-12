import { Component, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Book } from 'src/app/DataTypes';
import { AuthorService } from 'src/app/services/author/author.service';
import { BookService } from 'src/app/services/book/book.service';
import { GenreService } from 'src/app/services/genre/genre.service';
import { PublisherService } from 'src/app/services/publisher/publisher.service';
@Component({
  selector: 'Alt-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css'],
})
export class AddBookComponent {
  isList: any;
  subList = 3;
  AddBookSuccessMessage: string | undefined;
  AddBookFailMessage: string | undefined;
  FieldRequiredMessage = 'Field Is Required';

  authors: Array<string> = [];
  public selectedAuthors: Array<string> = [];
  genres: Array<string> = [];
  public selectedGenres: Array<string> = [];
  publishers: Array<string> = [];
  public selectedPublishers: Array<string> = [];

  constructor(
    private router: Router,
    private bookService: BookService,
    private genreService: GenreService,
    private authorService: AuthorService,
    private publisherService: PublisherService
  ) {}
  ngOnInit() {
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
  cancelAddBookForm() {
    this.router.navigate(['/Book']);
  }
  AddBook(request: Book, addBookForm: NgForm) {
    this.bookService.addBook(request).subscribe((result) => {
      if (result) {
        this.AddBookSuccessMessage = 'Book Added Successfully';
        addBookForm.reset();
        setTimeout(() => {
          this.AddBookSuccessMessage = undefined;
          this.router.navigate(['/Book']).then(() => {
            window.location.reload();
          });
        }, 2000);
      } else {
        this.AddBookFailMessage = 'Unsuccessfull Add Operation';
        setTimeout(() => {
          this.AddBookFailMessage = undefined;
        }, 2000);
      }
    });
  }
}
