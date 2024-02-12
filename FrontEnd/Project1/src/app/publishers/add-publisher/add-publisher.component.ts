import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Publisher } from 'src/app/DataTypes';
import { PublisherService } from 'src/app/services/publisher/publisher.service';

@Component({
  selector: 'Alt-add-publisher',
  templateUrl: './add-publisher.component.html',
  styleUrls: ['./add-publisher.component.css'],
})
export class AddPublisherComponent {
  AddPublisherSuccessMessage: string | undefined;
  AddPublisherFailMessage: string | undefined;
  FieldRequiredMessage = 'Field Is Required';
  constructor(
    private router: Router,
    private publisherService: PublisherService
  ) {}
  cancelAddPublisherForm() {
    this.router.navigate(['/Publisher']);
  }
  AddPublisher(request: Publisher, addPublisherForm: NgForm) {
    this.publisherService.AddPublisher(request).subscribe((result) => {
      if (result) {
        this.AddPublisherSuccessMessage = 'Publisher Added Successfully';
        addPublisherForm.reset();
        setTimeout(() => {
          this.AddPublisherSuccessMessage = undefined;
          this.router.navigate(['/Publisher']).then(() => {
            window.location.reload();
          });
        }, 2000);
      } else {
        this.AddPublisherFailMessage = 'Unsuccessfull Add Operation';
        setTimeout(() => {
          this.AddPublisherFailMessage = undefined;
        }, 2000);
      }
    });
  }
}
