import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';
import { AccountsComponent } from './modules/accounts/accounts/accounts.component';
import { BanksComponent } from './modules/banks/banks/banks.component';
import { CurrencyComponent } from './modules/currency/currency/currency.component';
import { CustomerComponent } from './modules/customers/customer/customer.component';
import { LedgerComponent } from './modules/ledgers/ledger/ledger.component';
import { LoginComponent } from './modules/login/login/login.component';
import { SuppliersComponent } from './modules/suppliers/suppliers/suppliers.component';
import { DashboardComponent } from './modules/dashboard/dashboard/dashboard.component';
import { AccountPayableComponent } from './modules/reports/account_payable/account-payable/account-payable.component';
import { AccountReceivableComponent } from './modules/reports/account_receivable/account-receivable/account-receivable.component';
import { BalanceSheetComponent } from './modules/reports/balance_sheet/balance-sheet/balance-sheet.component';
import { IncomeStatementComponent } from './modules/reports/income_statement/income-statement/income-statement.component';
import { TrialBalanceComponent } from './modules/reports/trial_balance/trial-balance/trial-balance.component';
import { UsersModule } from './modules/users/users/users.module';
import { SideNavComponent } from './shared/side-nav/side-nav.component';
<<<<<<< HEAD
import { MainNavComponent } from './shared/main-nav/main-nav.component';
import { ListViewModule } from '@syncfusion/ej2-ng-lists';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { GridModule } from '@syncfusion/ej2-ng-grids';


=======

import { CompanyModule } from './modules/company/company.module';
>>>>>>> 7268e7ec44c93464c283252f7b8d93f94e525a29

@NgModule({
  declarations: [
    AppComponent,
    AccountsComponent,

    BanksComponent,
    CurrencyComponent,
    CustomerComponent,
    LedgerComponent,
    LoginComponent,
    SuppliersComponent,
    DashboardComponent,
    AccountPayableComponent,
    AccountReceivableComponent,
    BalanceSheetComponent,
    IncomeStatementComponent,
    TrialBalanceComponent,
    SideNavComponent,
    // modules
<<<<<<< HEAD
    MainNavComponent,
    SideNavComponent,
=======
  //  UsersModule
>>>>>>> 7268e7ec44c93464c283252f7b8d93f94e525a29
  ],
  imports: [
    BrowserModule,
    CompanyModule,
    MatSidenavModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    UsersModule,
    RouterModule,
    CommonModule,

    // sincfussion modules
    ListViewModule,
    ButtonModule,
    GridModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


// <a mat-list-item *ngFor="let link of menu" routerLincActive="active" [routerLink]="link.path">
// <mat-icon>{{link.icon}}</mat-icon>
// {{link.label}}
// </a>
