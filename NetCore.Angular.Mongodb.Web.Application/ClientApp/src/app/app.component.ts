import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'client-side';

  paymentModes: string[] = ['debit card', 'credit card', 'cash'];
}
