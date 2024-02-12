import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorComponent } from './author/author.component';
import { AddAuthorComponent } from './add-author/add-author.component';
import { EditAuthorComponent } from './edit-author/edit-author.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [AuthorComponent, AddAuthorComponent, EditAuthorComponent],
  imports: [CommonModule, FormsModule],
  exports: [],
})
export class AuthorsModule {}
