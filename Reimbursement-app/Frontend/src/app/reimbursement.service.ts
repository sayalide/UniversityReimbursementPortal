import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReimbursementService {

  private apiUrl = 'http://localhost:5000/api/receipts';  //  API URL

  constructor(private http: HttpClient) { }

  submitReceipt(formData: FormData): Observable<any> {
    return this.http.post(this.apiUrl, formData);
  }
}
