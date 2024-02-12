import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Author, BaseURL } from 'src/app/DataTypes';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  URL = 'Author/';
  constructor(private httpClient: HttpClient) {}

  getAllAuthors(): Observable<Array<Author>> {
    return this.httpClient.get<Array<Author>>(
      `${BaseURL}${this.URL}GetAllAuthors`
    );
  }
  getAuthorByName(name: string): Observable<Author> {
    return this.httpClient.get<Author>(
      `${BaseURL}${this.URL}GetAuthorByName/${name}`
    );
  }
  deleteAuthor(name: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(
      `${BaseURL}${this.URL}DeleteAuthor/${name}`
    );
  }
  updateAuthor(name: string, request: Author): Observable<boolean> {
    return this.httpClient.put<boolean>(
      `${BaseURL}${this.URL}UpdateAuthor/${name}`,
      request
    );
  }
  addAuthor(request: Author): Observable<boolean> {
    debugger;
    return this.httpClient.post<boolean>(
      `${BaseURL}${this.URL}AddAuthor`,
      request
    );
  }
}
