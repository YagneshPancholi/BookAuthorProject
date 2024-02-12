import { Component, TemplateRef } from '@angular/core';
import { Book } from 'src/app/DataTypes';
import { BookService } from 'src/app/services/book/book.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';

@Component({
  selector: 'Alt-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent {
  books: Array<Book> = [];
  modalRef!: BsModalRef;
  message: string | undefined;

  constructor(
    private bookService: BookService,
    private modalService: BsModalService,
    private router: Router
  ) {}
  ngOnInit() {
    this.loadAllBooks();
  }
  loadAllBooks() {
    this.bookService.getAllBooks().subscribe((result) => {
      this.books = result;
    });
  }
  showAlert(template: TemplateRef<Book>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirm(bookName: string): void {
    this.bookService.deleteBook(bookName).subscribe((result) => {
      if (result == true) {
        this.message = 'Book Deleted Successfully...';
      } else {
        this.message = 'Unsuccessfull Book Delete';
      }
      setTimeout(() => {
        this.message = undefined;
        this.loadAllBooks();
        window.location.reload();
      }, 2000);
    });

    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
  navigateToAddBook() {
    this.router.navigate(['/addBook']);
  }
  navigateToEditPage(name: string) {
    this.router.navigate([`/editBook/${name}`]);
  }
}
