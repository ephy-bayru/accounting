import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
// class, service, grid and routings are imported here
import { CurrencyComponent } from './currency.component';
import { CurrencyService } from './../currency.service';
import { CurrencyRoutingModule } from './../currency-routing/currency-routing.module';
import { CurrencyGridComponent } from './../currency-grid/currency-grid.component';
// syncfussion modules
import { ButtonModule, RadioButtonModule, SwitchModule } from '@syncfusion/ej2-angular-buttons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule, ResizeService, ExcelExportService } from '@syncfusion/ej2-angular-grids';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import {
  PageService,
  SortService,
  FilterService,
  GroupService,
  EditService,
  ColumnChooserService,
  ColumnMenuService,
  DetailRowService,
  SearchService,
  PdfExportService,
  ReorderService,
  CommandColumnService,
  ToolbarService, FreezeService, SelectionService
} from '@syncfusion/ej2-angular-grids';

@NgModule({
  imports: [
    CommonModule,
    CurrencyRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    RadioButtonModule,
    DatePickerModule,
    GridModule,
    SwitchModule
  ],
  declarations: [
    CurrencyGridComponent,
    CurrencyComponent
  ],
  providers: [
    CurrencyService,
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
    ResizeService,
    PageService,
    FreezeService,
    SelectionService,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CurrencyModule { }
