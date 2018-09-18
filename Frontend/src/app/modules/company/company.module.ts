import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserModule } from '@angular/platform-browser';
import { CompanyRoutingModule } from './company-routing.module';
import { CompanyViewComponent } from './comapny-view/comapny-view.component';
import { ComapnyFormComponent } from './comapny-form/comapny-form.component';
import {
  GridModule, EditService, ToolbarService, GroupService, PdfExportService,
  ExcelExportService, ColumnMenuService, SearchService, DetailRowService,
  PageService, SortService, FilterService, ColumnChooserService, ReorderService, CommandColumnService, ResizeService
} from '@syncfusion/ej2-ng-grids';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { FormOptionsComponent } from '../../shared/form-options/form-options.component';
import { CompanyService } from './company.service';


@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    GridModule,
    CompanyRoutingModule,
    ReactiveFormsModule,
    // syncfussion modules
    ButtonModule,
  ],
  declarations: [CompanyViewComponent, ComapnyFormComponent, FormOptionsComponent],
  exports: [CompanyViewComponent, ComapnyFormComponent],
  providers: [   PageService,
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
    CompanyService,
    ToolbarService,
    ResizeService]
})

export class CompanyModule { }
