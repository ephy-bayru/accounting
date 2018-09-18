import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';

import { AppComponent } from './app.component';
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
import { MainNavComponent } from './shared/main-nav/main-nav.component';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { GridModule } from '@syncfusion/ej2-ng-grids';
import { CompanyModule } from './modules/company/company.module';
import { RmHeaderInterceptorService } from './shared/rm-header-interceptor.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SidebarModule, TreeViewComponent, ToolbarComponent } from '@syncfusion/ej2-angular-navigations';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { CompareDirective } from './shared/compare.directive';


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


    MainNavComponent,
    SideNavComponent,
    // syncfusion
    TreeViewComponent, ToolbarComponent, CompareDirective
  ],
  imports: [
    BrowserModule,
    UsersModule,
    RouterModule,
    CommonModule,
    CompanyModule,
    // sincfussion modules
    ButtonModule,
    GridModule,
    SidebarModule,
    AppRoutingModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: RmHeaderInterceptorService, multi: true},
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
