import { NgModule, TemplateRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenreComponent } from './genre/genre.component';
import { AddGenreComponent } from './add-genre/add-genre.component';
import { FormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [GenreComponent, AddGenreComponent],
  imports: [CommonModule, FormsModule, ModalModule],
})
export class GenresModule {}
