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
      id: '1', name: 'Home'
    },
    {
      id: '2', name: 'General Ledger',
      subChild: [
        {
          id: 'ledgers', name: 'G/L Registry'
        },
        {
          id: 'accounts', name: 'Account Chart'
        }
      ]
    },
    {
      id: '3', name: 'Cash Managment',
      subChild: [
        { id: 'banks', name: 'Banks' }
      ]
    },
    {
      id: '4', name: 'Cash Flow'
    },
    {
      id: '5', name: 'Recievables',
      subChild: [
        { id: 'customers', name: 'CUSTOMER', tooltip: 'customers data'  }
      ]
    },
    {
      id: '6', name: 'Payables',
      subChild: [
        { id: 'suppliers', name: 'Suppliers'  }
      ]
    },
    {
      id: '7', name: 'Recurring Activities',
      subChild: [
        {
          id: '7-01', name: 'G/L Entry'
        },
        {
          id: '7-02', name: 'VAT'
        },
        {
          id: '7-03', name: 'Fiscal Year'
        },
        {
          id: '7-04', name: 'Recievables'
        }

      ]
    },
    {
      id: '8', name: 'Settings',
      subChild: [

        { id: 'organizations', name: 'Company Profile' },
        { id: 'calanders', name: 'Accounting Period' },
        { id: 'employees', name: 'USER', tooltip: 'User Managment' },
        { id: 'currencies', name: 'CURRENCY' },
        {  id: 'exrate', name: 'Exchange Rate' }

      ]
    },
    {
      id: '9', name: 'Reports',
      subChild: [
        {
          id: 'invoices', name: 'Trial BAlance'
        },
        {
          id: '9-01', name: 'Balance Sheet'
        },
        {
          id: '9-02', name: 'Income Statement'
        },
      ]
    }
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
  constructor(private router: Router) { }

  nodeSelected(args: NodeSelectEventArgs) {
    this.router.navigate([args.node.dataset['uid']]);
  }

}
