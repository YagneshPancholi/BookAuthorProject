import { Component, TemplateRef, RendererFactory2 } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Book, Genre } from 'src/app/DataTypes';
import { GenreService } from 'src/app/services/genre/genre.service';
@Component({
  selector: 'Alt-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css'],
})
export class GenreComponent {
  genres: Array<Genre> = [];
  modalRef!: BsModalRef;
  message: string | undefined;
  constructor(
    private genreService: GenreService,
    private router: Router,
    private modalService: BsModalService
  ) {}
  ngOnInit() {
    this.loadAllGenres();
  }
  loadAllGenres() {
    this.genreService.getAllGenres().subscribe((result) => {
      this.genres = result;
    });
  }
  showAlert(template: TemplateRef<Book>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirm(genreName: string): void {
    this.genreService.deleteGenre(genreName).subscribe((result: boolean) => {
      console.warn(result);
      if (result == true) {
        this.message = 'Genre Deleted Successfully...';
      } else {
        this.message = 'Unsuccessfull Genre Delete';
      }
      setTimeout(() => {
        this.message = undefined;
        this.loadAllGenres();
        window.location.reload();
      }, 2000);
    });

    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
  navigateToAddGenre() {
    this.router.navigate(['/addGenre']);
  }
}
