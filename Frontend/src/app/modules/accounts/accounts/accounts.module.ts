import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';

import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AccountsRoutingModule } from '../accounts-routing/accounts-routing.module';
import { AccountsComponent } from './accounts.component';
import { SwitchModule, ButtonModule } from '@syncfusion/ej2-ng-buttons';

@NgModule({
  imports: [
    CommonModule,
    DropDownListModule,
    ReactiveFormsModule,
    ButtonModule,
    BrowserModule,
    SwitchModule,
    AccountsRoutingModule
  ],
  declarations: [AccountsComponent]
})
export class AccountsModule { }
