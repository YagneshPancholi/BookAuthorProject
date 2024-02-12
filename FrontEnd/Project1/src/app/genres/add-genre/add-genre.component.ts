import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Genre } from 'src/app/DataTypes';
import { GenreService } from 'src/app/services/genre/genre.service';

@Component({
  selector: 'Alt-add-genre',
  templateUrl: './add-genre.component.html',
  styleUrls: ['./add-genre.component.css'],
})
export class AddGenreComponent {
  AddGenreSuccessMessage: string | undefined;
  AddGenreFailMessage: string | undefined;
  FieldRequiredMessage = 'Field Is Required';
  constructor(private router: Router, private genreService: GenreService) {}
  cancelAddGenreForm() {
    this.router.navigate(['/Genre']);
  }
  AddGenre(request: Genre, addGenreForm: NgForm) {
    this.genreService.AddGenre(request).subscribe((result) => {
      if (result) {
        this.AddGenreSuccessMessage = 'Genre Added Successfully';
        addGenreForm.resetForm();
        setTimeout(() => {
          this.AddGenreSuccessMessage = undefined;
          this.router.navigate(['/Genre']).then(() => {
            window.location.reload();
          });
        }, 2000);
      } else {
        this.AddGenreFailMessage = 'Unsuccessfull Add Operation';
        setTimeout(() => {
          this.AddGenreFailMessage = undefined;
        }, 2000);
      }
    });
  }
}
