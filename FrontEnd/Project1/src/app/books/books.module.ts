import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './books/books.component';
import { AddBookComponent } from './add-book/add-book.component';
import { EditBookComponent } from './edit-book/edit-book.component';
import { FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LabelModule } from '@progress/kendo-angular-label';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
@NgModule({
  declarations: [BooksComponent, AddBookComponent, EditBookComponent],
  imports: [
    CommonModule,
    FormsModule,
    DropDownsModule,
    LabelModule,
    InputsModule,
    ButtonsModule,
  ],
  exports: [BooksComponent, AddBookComponent, EditBookComponent],
})
export class BooksModule {}
