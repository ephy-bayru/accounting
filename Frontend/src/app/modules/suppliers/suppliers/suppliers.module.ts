import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { SuppliersComponent } from './suppliers.component';
import { SuppliersService } from './../suppliers.service';
import { SuppliersGridComponent } from './../suppliers-grid/suppliers-grid.component';
import { SuppliersRoutingModule } from './../suppliers-routing/suppliers-routing.module';
import { ButtonModule, RadioButtonModule, SwitchModel, SwitchModule } from '@syncfusion/ej2-ng-buttons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule, ExcelExportService } from '@syncfusion/ej2-ng-grids';
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
  ToolbarService
} from '@syncfusion/ej2-ng-grids';

@NgModule({
  imports: [
    CommonModule,
    SuppliersRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    RadioButtonModule,
    DatePickerModule,
    GridModule, SwitchModule
  ],
  declarations: [
    SuppliersComponent,
    SuppliersGridComponent
  ],
  providers: [
    SuppliersService,
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
    PageService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SuppliersModule { }
