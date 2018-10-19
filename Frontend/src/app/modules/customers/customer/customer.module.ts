import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
// class, service, grid and routings are imported here
import { CustomerComponent } from './customer.component';
import { CustomerService } from './../customer.service';
import { CustomerRoutingModule } from './../customer-routing/customer-routing.module';
import { CustomerGridComponent } from './../customer-grid/customer-grid.component';
// syncfussion modules
import { ButtonModule, RadioButtonModule } from '@syncfusion/ej2-ng-buttons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule, ResizeService, ExcelExportService } from '@syncfusion/ej2-ng-grids';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import {
  GridComponent,
  FilterSettingsModel,
  SelectionSettingsModel,
  GroupSettingsModel,
  EditSettingsModel,
  TextWrapSettingsModel,
} from '@syncfusion/ej2-ng-grids';
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
  ToolbarService, FreezeService, SelectionService, CommandModel
} from '@syncfusion/ej2-ng-grids';

@NgModule({
  imports: [
    CommonModule,
    CustomerRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    RadioButtonModule,
    DatePickerModule,
    GridModule
  ],
  declarations: [
    CustomerComponent,
    CustomerGridComponent,
  ],
  providers: [
    CustomerService,
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
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class CustomerModule { }
