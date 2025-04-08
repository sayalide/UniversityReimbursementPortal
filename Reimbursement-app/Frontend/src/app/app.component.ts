import { Component } from '@angular/core';
import { ReceiptFormComponent } from './receipt-form/receipt-form.component';  // Ensure the correct import

@Component({
  selector: 'app-root',
  standalone: true,  // Marks this as a standalone component
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  imports: [ReceiptFormComponent]  // Include ReceiptFormComponent in the imports array
})
export class AppComponent {
  title = 'ReimbursementApp';
}
