import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';  // Import HttpClientModule
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-receipt-form',
  standalone: true,
  templateUrl: './receipt-form.component.html',
  styleUrls: ['./receipt-form.component.scss'],
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule]  //  HttpClientModule 
})
export class ReceiptFormComponent {
  receiptForm: FormGroup;
  selectedFile: File | null = null;
  formSubmitted: boolean = false;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.receiptForm = this.fb.group({
      date: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(0.01)]],
      description: ['', Validators.required]
    });
  }

  // Handle file selection
  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    this.selectedFile = input.files && input.files.length ? input.files[0] : null;
  }

  // Handle form submission
  onSubmit() {
    if (this.receiptForm.invalid || !this.selectedFile) {
      alert("Please complete the form and select a file.");
      return;
    }
  
    const formData = new FormData();
    formData.append('date', this.receiptForm.value.date);
    formData.append('amount', this.receiptForm.value.amount);
    formData.append('description', this.receiptForm.value.description);
    formData.append('receipt', this.selectedFile);
  
    // Ensure URL is correct for your backend (e.g., http://localhost:5141/api/receipts)
    this.http.post('http://localhost:5141/api/receipts', formData).subscribe({
      next: res => {
        this.formSubmitted = true;
        alert("Receipt submitted successfully!");
        this.receiptForm.reset();
        this.selectedFile = null;
      },
      error: err => {
        alert("Submission failed: " + err.message);
      }
    });
  }
}
