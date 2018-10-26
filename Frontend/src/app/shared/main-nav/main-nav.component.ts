import { Component, ViewEncapsulation, Inject, ViewChild } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { SidebarComponent, TreeViewComponent } from '@syncfusion/ej2-angular-navigations';
import { Router } from '@angular/router';
import { NodeSelectEventArgs } from '@syncfusion/ej2-navigations';


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
            { id: 'organizations', name: 'PROFILE' },
            { id: 'calanders', name: 'CALENDER'},
        ]
        },
        {
          id: 'employees', name: 'USER', tooltip: 'users data'
        },
        {
          id: 'customers', name: 'CUSTOMER', tooltip: 'customers data'
        },
        {
          id: 'suppliers', name: 'SUPPLIER'
        },
        {
          id: 'banks', name: 'BANK'
        },
        {
          id: 'currencies', name: 'CURRENCY'
        },
        {
          id: 'exrate', name: 'EXCAHNGE RATE'
        }
      ],
    },
    {
      id: 'accounts', name: 'ACCOUNTS'
    },
    {
      id: 'ledgers', name: 'General Ledger'
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

  nodeSelected(args: NodeSelectEventArgs) {
    this.router.navigate([args.node.dataset['uid']]);
  }

}
