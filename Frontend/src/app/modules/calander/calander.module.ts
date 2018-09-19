import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CalanderRoutingModule } from './calander-routing.module';
import { CalanderFormComponent } from './calander-form/calander-form.component';
import { CalanderViewComponent } from './calander-view/calander-view.component';
import {
  PageService, SortService, FilterService, GroupService, EditService,
  ExcelExportService, ColumnChooserService, ColumnMenuService, DetailRowService,
  SearchService, PdfExportService, ReorderService, CommandColumnService,
  ToolbarService, ResizeService, GridModule
} from '@syncfusion/ej2-ng-grids';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CalanderService } from './calander.service';
import { DateRangePickerModule } from '@syncfusion/ej2-angular-calendars';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    CalanderRoutingModule,
    GridModule,
    ReactiveFormsModule,
    DateRangePickerModule,
    ButtonModule
  ],
  declarations: [CalanderFormComponent, CalanderViewComponent],
  providers: [PageService,
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
    CalanderService,
    ToolbarService,
    ResizeService]
})
export class CalanderModule { }
