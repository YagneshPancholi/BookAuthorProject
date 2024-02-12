import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddPublisherComponent } from './add-publisher/add-publisher.component';
import { PublisherComponent } from './publisher/publisher.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [PublisherComponent, AddPublisherComponent],
  imports: [CommonModule, FormsModule],
})
export class PublishersModule {}
