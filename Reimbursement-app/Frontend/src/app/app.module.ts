import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';  // Import ReactiveFormsModule
import { HttpClientModule } from '@angular/common/http'; // Import HttpClientModule

import { ReceiptFormComponent } from './receipt-form/receipt-form.component'; // Import  component

@NgModule({
  declarations: [],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    ReceiptFormComponent  // Import standalone ReceiptFormComponent
  ],
  providers: [],
  // 
})
export class AppModule { }
