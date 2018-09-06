import { Component, OnInit, ViewChild } from '@angular/core';
import {  } from './../users.service';
// import { data } from './data-source';
import { ToolbarItems } from '@syncfusion/ej2-ng-grids';
import { ClickEventArgs } from '@syncfusion/ej2-ng-navigations';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import {
  SortService,
  GroupService,
  ColumnMenuService,
  PageService,
  FilterService,
  ContextMenuItem,
  GroupSettingsModel,
  FilterSettingsModel,
  EditSettingsModel,
  TextWrapSettingsModel,
  GridComponent,
  ToolbarService,
  ExcelExportService,
  PdfExportService,
  SelectionSettingsModel,
  ExcelExportCompleteArgs,
  PdfExportCompleteArgs,
  FreezeService
} from '@syncfusion/ej2-ng-grids';

@Component({
  selector: 'app-user-grid',
  templateUrl: './user-grid.component.html',
  styleUrls: ['./user-grid.component.css'],
  providers: [
    SortService,
    GroupService,
    ColumnMenuService,
    PageService,
    PdfExportService,
    FreezeService,
    FreezeService,
    FilterService,
    ToolbarService,
    ExcelExportService,
  ]
})
export class UserGridComponent implements OnInit {
  title = 'sinkT';
  SERVICE_URI: 'http://localhost/api/users';
  @ViewChild('grid')
  public grid: GridComponent;
  public data: DataManager;
  // public data: object[];
  public gridd: GridComponent;
  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public filterOptions: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public selectionOptions: SelectionSettingsModel;
  constructor() {}

  ngOnInit() {
    // this.data = this.data;
        // fetching data from api
    this.data = new DataManager({
      url: this.SERVICE_URI,
      adaptor: new WebApiAdaptor(),
      crossDomain: true,
      enableCaching: true,
      cachingPageSize: 10,
      timeTillExpiration: 100000
    });
    this.toolbarOptions = ['ColumnChooser'];
    this.groupOptions = { showGroupedColumn: true };
    this.filterSettings = { type: 'CheckBox' };
    this.wrapSettings = { wrapMode: 'Content' };
    this.toolbarOptions = [
      'Add',
      'Edit',
      'Delete',
      'Update',
      'Cancel',
      'Print',
      'PdfExport',
      'ExcelExport',
      'Search'
    ];
    this.editSettings = {
      allowEditing: true,
      allowAdding: true,
      allowDeleting: true,
      mode: 'Dialog'
    };
    this.filterOptions = {
      // type: 'Menu'
      ignoreAccent: true
    };
    this.selectionOptions = { mode: 'Both' };
  }
  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'PdfExport') {
      this.grid.pdfExport();
    }
    // if (args.item.id === 'Grid_add') { // 'Grid_pdfexport' -> Grid component id + _ + toolbar item name
    //   alert('add');
    // }
    if (args.item.id === 'ExcelExport') {
      this.grid.excelExport();
    }
  }
}
