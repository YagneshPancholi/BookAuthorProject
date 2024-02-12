import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseURL, Genre, Publisher } from 'src/app/DataTypes';

@Injectable({
  providedIn: 'root',
})
export class PublisherService {
  Url = 'Publisher/';
  constructor(private httpClient: HttpClient) {}
  getAllPublishers(): Observable<Array<Publisher>> {
    return this.httpClient.get<Array<Publisher>>(
      `${BaseURL}${this.Url}GetAllPublishers`
    );
  }
  deletePublisher(name: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(
      `${BaseURL}${this.Url}DeletePublisher/${name}`
    );
  }
  AddPublisher(request: Publisher): Observable<boolean> {
    return this.httpClient.post<boolean>(
      `${BaseURL}${this.Url}AddPublisher`,
      request
    );
  }
}
