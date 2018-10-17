import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { LedgerComponent } from './ledger.component';
import { LedgerService } from '../ledger.service';
import { LedgerRoutingModule } from '../ledger-routing/ledger-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { GridModule } from '@syncfusion/ej2-ng-grids';
import { NumericTextBoxComponent } from '@syncfusion/ej2-ng-inputs';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DatePickerModule,
    DropDownListModule,
    ButtonModule,
    LedgerRoutingModule,
    BrowserModule,
    GridModule,
  ],
  declarations: [LedgerComponent, NumericTextBoxComponent],
  providers: [LedgerService]
})
export class LedgerModule { }
