import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { basePlacements } from '@popperjs/core';
import { Observable, ObservableInput } from 'rxjs';
import { BaseURL, Genre } from 'src/app/DataTypes';
import { BooksComponent } from 'src/app/books/books/books.component';

@Injectable({
  providedIn: 'root',
})
export class GenreService {
  Url = 'Genre/';
  constructor(private httpClient: HttpClient) {}
  getAllGenres(): Observable<Array<Genre>> {
    setTimeout(() => {}, 10000);
    return this.httpClient.get<Array<Genre>>(
      `${BaseURL}${this.Url}GetAllGenres`
    );
  }
  deleteGenre(name: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(
      `${BaseURL}${this.Url}DeleteGenre/${name}`
    );
  }
  AddGenre(request: Genre): Observable<boolean> {
    return this.httpClient.post<boolean>(
      `${BaseURL}${this.Url}AddGenre`,
      request
    );
  }
}
