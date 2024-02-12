import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from 'src/app/DataTypes';
import { Observable, catchError, of } from 'rxjs';
import { sendUpdateBookData } from 'src/app/books/edit-book/edit-book.component';
@Injectable({
  providedIn: 'root',
})
export class BookService {
  Url: string = 'https://localhost:7034/api/Book/';
  constructor(private httpClient: HttpClient) {}

  getAllBooks(): Observable<Array<Book>> {
    return this.httpClient.get<Array<Book>>(`${this.Url}GetAllBooks`);
  }
  getBookByName(name: string): Observable<Book> {
    return this.httpClient.get<Book>(`${this.Url}GetBookByName/${name}`);
  }
  addBook(book: Book): Observable<boolean> {
    return this.httpClient.post<boolean>(`${this.Url}AddBook`, book);
  }
  updateBook(name: string, book: Book): Observable<boolean> {
    debugger;
    return this.httpClient.put<boolean>(`${this.Url}UpdateBook/${name}`, book);
  }
  deleteBook(name: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.Url}DeleteBook/${name}`);
  }
}
