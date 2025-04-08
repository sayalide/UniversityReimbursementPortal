import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { ReceiptFormComponent } from './receipt-form/receipt-form.component';  // Import your form component
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let app: AppComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent, ReceiptFormComponent],  // Declare  components 
      imports: [ReactiveFormsModule, HttpClientTestingModule],  // Import required modules for testing
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    app = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app component', () => {
    expect(app).toBeTruthy();
  });

  it('should render the receipt form', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('app-receipt-form')).toBeTruthy();  // Check if the receipt form component is rendered
  });

  it('should have the correct title', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    const title = compiled.querySelector('h1')?.textContent;
    expect(title).toContain('Receipt Reimbursement Form');  //  app component contains a title like this
  });
});
