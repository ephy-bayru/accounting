import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';

  public data = [
    {value: '10,000 birr', headerText: 'Total Recievables', actionText: 'View'},
    {value: '50,000 birr', headerText: 'Total Payables', actionText: 'View'},
    {value: '100', headerText: 'Accounts', actionText: 'View'},
    {value: '20', headerText: 'Suppliers', actionText: 'View'},

  ];
}
