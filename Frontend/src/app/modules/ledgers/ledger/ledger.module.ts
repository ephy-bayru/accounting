import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { LedgerComponent } from './ledger.component';
import { LedgerService } from '../ledger.service';
import { LedgerRoutingModule } from '../ledger-routing/ledger-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import {
  GridModule, ToolbarService, SortService, FilterService, GroupService,
  EditService, ExcelExportService, ColumnChooserService, ColumnMenuService, DetailRowService,
  SearchService, PdfExportService, ReorderService, CommandColumnService, ResizeService
} from '@syncfusion/ej2-ng-grids';
import { NumericTextBoxModule } from '@syncfusion/ej2-ng-inputs';
import { ButtonModule, SwitchModule } from '@syncfusion/ej2-ng-buttons';
import { PaymentEntryFormComponent } from '../payment-entry-form/payment-entry-form.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DatePickerModule,
    DropDownListModule,
    ButtonModule,
    LedgerRoutingModule,
    BrowserModule,
    NumericTextBoxModule,
    GridModule,
    SwitchModule,
  ],
  declarations: [LedgerComponent, PaymentEntryFormComponent],
  providers: [LedgerService,
    SortService,
    FilterService,
    GroupService,
    EditService,
    ExcelExportService,
    ColumnChooserService,
    ColumnMenuService,
    DetailRowService,
    SearchService,
    PdfExportService,
    ReorderService,
    CommandColumnService,
    ToolbarService,
    ResizeService]
})
export class LedgerModule { }
