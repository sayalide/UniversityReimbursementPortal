import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';  // Import the standalone AppComponent

bootstrapApplication(AppComponent)
  .catch(err => console.error(err));  // Handle any errors during bootstrapping
