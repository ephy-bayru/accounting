import { Component, ViewEncapsulation, Inject, ViewChild } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { SidebarComponent, TreeViewComponent } from '@syncfusion/ej2-angular-navigations';
import { Router } from '@angular/router';


@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
  title = 'sidebar';
  @ViewChild('sidebar')
  public sidebar: SidebarComponent;
  public type: 'Push';
  public target: '.content';
  @ViewChild('togglebtn')
  public togglebtn: ButtonComponent;
  public hierarchicalData: Object[] = [
    {
      id: '1', name: 'ORGANIZATION',
      subChild: [
        {
          id: '01', name: 'COMPANY',
          subChild: [
            { id: '001', name: 'PROFILE', navigateUrl: 'organizations' },
            { id: '002', name: 'CALENDER', navigateUrl: 'calanders' },
        ]
        },
        {
          id: '01-02', name: 'USER', tooltip: 'users data', navigateUrl: 'employees'
        },
        {
          id: '01-03', name: 'CUSTOMER'
        },
        {
          id: '01-04', name: 'SUPPLIER'
        },
        {
          id: '01-05', name: 'BANK'
        },
        {
          id: '01-06', name: 'CURRENCY'
        }
      ],
    },
    {
      id: '02', name: 'ACCOUNTS',
      subChild: []
    },
    {
      id: '03', name: 'REPORTS',
      subChild: [
        {
          id: '03-01', name: 'TRIAL BALANCE',
        },
        {
          id: '03-02', name: 'BALANCE SHEEET',
        },
        {
          id: '03-03', name: 'INCOME STATMENT',
        },
        {
          id: '03-04', name: 'ACCOUNT PAYABLE',
        },
        {
          id: '03-03', name: 'ACOUNT RECEIVABLE',
        },
      ]
    },

  ];
  public field: Object = { dataSource: this.hierarchicalData, id: 'id', text: 'name', child: 'subChild' };
  btnClick() {
    if (this.togglebtn.element.classList.contains('e-active')) {
      this.togglebtn.content = 'Open';
      this.sidebar.hide();
      this.sidebar.type = 'Push';
    } else {
      this.togglebtn.content = 'Close';
      this.sidebar.type = 'Push';
      this.sidebar.show();
    }
  }
  constructor(private router: Router) {}

  goUsers() {
    this.router.navigate(['users']);
  }

}
