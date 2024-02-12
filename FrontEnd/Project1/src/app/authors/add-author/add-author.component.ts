import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Author } from 'src/app/DataTypes';
import { AuthorService } from 'src/app/services/author/author.service';

@Component({
  selector: 'Alt-add-author',
  templateUrl: './add-author.component.html',
  styleUrls: ['./add-author.component.css'],
})
export class AddAuthorComponent {
  AddAuthorSuccessMessage: string | undefined;
  AddAuthorFailMessage: string | undefined;
  FieldRequiredMessage = 'Field Is Required';
  constructor(
    private router: Router,
    private authorService: AuthorService,
    private datePipe: DatePipe
  ) {}
  cancelAddAuthorForm() {
    this.router.navigate(['/Author']);
  }
  AddAuthor(tempRequest: Author, addAuthorForm: NgForm) {
    tempRequest.birthDate = this.datePipe.transform(
      tempRequest.birthDate,
      'MM/dd/yyyy'
    );
    this.authorService.addAuthor(tempRequest).subscribe((result) => {
      if (result) {
        this.AddAuthorSuccessMessage = 'Author Added Successfully';
        addAuthorForm.resetForm();
        setTimeout(() => {
          this.AddAuthorSuccessMessage = undefined;
          this.router.navigate(['/Author']).then(() => {
            window.location.reload();
          });
        }, 2000);
      } else {
        this.AddAuthorFailMessage = 'Unsuccessfull Add Operation';
        setTimeout(() => {
          this.AddAuthorFailMessage = undefined;
        }, 2000);
      }
    });
  }
}
