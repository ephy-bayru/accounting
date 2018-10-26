import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
// class, service, grid and routings are imported here
import { ExchangerateComponent } from './exchange_rate.component';
import { ExchangeRateService } from '../exchange_rate.service';
import { ExRateRoutingModule } from './../exchange-rate-routing/exchange-rate-routing.module';
import { ExRateGridComponent } from './../exchange-rate-grid/exchange-rate-grid.component';
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
    ExRateRoutingModule,
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
    ExRateGridComponent,
    ExchangerateComponent
  ],
  providers: [
    ExchangeRateService,
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
export class ExRateModule { }
