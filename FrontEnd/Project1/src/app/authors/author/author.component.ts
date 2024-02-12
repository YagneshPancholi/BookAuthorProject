import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Author, Book } from 'src/app/DataTypes';
import { AuthorService } from 'src/app/services/author/author.service';

@Component({
  selector: 'Alt-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent {
  authors: Array<Author> = [];
  modalRef!: BsModalRef;
  message: string | undefined;

  constructor(
    private authorService: AuthorService,
    private modalService: BsModalService,
    private router: Router
  ) {}
  ngOnInit() {
    this.loadAllAuthors();
  }
  loadAllAuthors() {
    this.authorService.getAllAuthors().subscribe((result) => {
      this.authors = result;
    });
  }
  showAlert(template: TemplateRef<Book>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirm(name: string): void {
    this.authorService.deleteAuthor(name).subscribe((result) => {
      if (result == true) {
        this.message = 'Author Deleted Successfully...';
      } else {
        this.message = 'Unsuccessfull Author Delete';
      }
      setTimeout(() => {
        this.message = undefined;
        this.loadAllAuthors();
        window.location.reload();
      }, 2000);
    });
    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
  navigateToAddAuthor() {
    this.router.navigate(['/addAuthor']);
  }
  navigateToEditPage(name: string) {
    this.router.navigate([`/editAuthor/${name}`]);
  }
}
