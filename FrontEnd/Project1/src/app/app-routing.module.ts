import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BooksComponent } from './books/books/books.component';
import { AuthorComponent } from './authors/author/author.component';
import { generate } from 'rxjs';
import { GenreComponent } from './genres/genre/genre.component';
import { PublisherComponent } from './publishers/publisher/publisher.component';
import { AddBookComponent } from './books/add-book/add-book.component';
import { EditBookComponent } from './books/edit-book/edit-book.component';
import { AddAuthorComponent } from './authors/add-author/add-author.component';
import { EditAuthorComponent } from './authors/edit-author/edit-author.component';
import { AddGenreComponent } from './genres/add-genre/add-genre.component';
import { AddPublisherComponent } from './publishers/add-publisher/add-publisher.component';

const routes: Routes = [
  {
    path: 'Book',
    component: BooksComponent,
  },
  {
    path: 'addBook',
    component: AddBookComponent,
  },
  {
    path: `editBook/:name`,
    component: EditBookComponent,
  },
  {
    path: 'Author',
    component: AuthorComponent,
  },
  {
    path: 'addAuthor',
    component: AddAuthorComponent,
  },
  {
    path: 'editAuthor/:name',
    component: EditAuthorComponent,
  },
  {
    path: 'Genre',
    component: GenreComponent,
  },
  {
    path: 'addGenre',
    component: AddGenreComponent,
  },
  {
    path: 'Publisher',
    component: PublisherComponent,
  },
  {
    path: 'addPublisher',
    component: AddPublisherComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
