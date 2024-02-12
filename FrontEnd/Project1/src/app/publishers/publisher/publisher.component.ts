import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Book, Publisher } from 'src/app/DataTypes';
import { PublisherService } from 'src/app/services/publisher/publisher.service';

@Component({
  selector: 'Alt-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css'],
})
export class PublisherComponent {
  publishers: Array<Publisher> = [];
  modalRef!: BsModalRef;
  message: string | undefined;
  constructor(
    private publisherService: PublisherService,
    private router: Router,
    private modalService: BsModalService
  ) {}
  ngOnInit() {
    this.loadAllPublishers();
  }
  loadAllPublishers() {
    this.publisherService.getAllPublishers().subscribe((result) => {
      this.publishers = result;
    });
  }

  showAlert(template: TemplateRef<Book>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirm(Name: string): void {
    this.publisherService.deletePublisher(Name).subscribe((result: boolean) => {
      console.warn(result);
      if (result == true) {
        this.message = 'Publisher Deleted Successfully...';
      } else {
        this.message = 'Unsuccessfull Publisher Delete';
      }
      setTimeout(() => {
        this.message = undefined;
        this.loadAllPublishers();
        window.location.reload();
      }, 2000);
    });

    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
  navigateToAddPublisher() {
    this.router.navigate(['/addPublisher']);
  }
}
