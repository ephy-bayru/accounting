import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DepositRoutingModule } from './deposit-routing.module';
import { DepositComponent } from './deposit/deposit.component';
import { GridModule } from '@syncfusion/ej2-angular-grids';

import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { ReactiveFormsModule } from '@angular/forms';
import { NumericTextBoxModule } from '@syncfusion/ej2-ng-inputs';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';

@NgModule({
  imports: [
    CommonModule,
    DepositRoutingModule,
    GridModule,
    DatePickerModule,
    DropDownListModule,
    ReactiveFormsModule,
    NumericTextBoxModule
  ],
  declarations: [DepositComponent]
})
export class DepositModule { }
