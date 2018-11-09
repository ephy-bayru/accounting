import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';

import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AccountsRoutingModule } from '../accounts-routing/accounts-routing.module';
import { AccountsComponent } from './accounts.component';
import { SwitchModule, ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { AccountsService } from '../accounts.service';
import { AggregateService, SortService, FilterService, GroupService,
  EditService, ExcelExportService, ColumnChooserService, ColumnMenuService,
  DetailRowService, SearchService, PdfExportService, ReorderService,
  CommandColumnService, ToolbarService, ResizeService } from '@syncfusion/ej2-ng-grids';
import { CompanyService } from '../../company/company.service';

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
  declarations: [AccountsComponent],
  providers: [AccountsService, AggregateService,
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
export class AccountsModule { }
