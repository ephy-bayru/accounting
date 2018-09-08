import { Component, OnInit, ViewChild } from '@angular/core';
import { ToolbarItems } from '@syncfusion/ej2-ng-grids';
import { ClickEventArgs } from '@syncfusion/ej2-ng-navigations';
import {
  SortService,
  GroupService,
  ColumnMenuService,
  PageService,
  FilterService,
  GroupSettingsModel,
  FilterSettingsModel,
  EditSettingsModel,
  TextWrapSettingsModel,
  GridComponent,
  ToolbarService,
  ExcelExportService,
  PdfExportService,
  SelectionSettingsModel,
  FreezeService
} from '@syncfusion/ej2-ng-grids';
import { Router } from '@angular/router';
import { CompanyService, Organization } from '../company.service';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-company-view',
  templateUrl: './comapny-view.component.html',
  styleUrls: ['./comapny-view.component.css'],
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

export class CompanyViewComponent implements OnInit {
  title = 'sinkT';

  @ViewChild('grid')
  public grid: GridComponent;
  public dataSource: Organization[];
  public data: DataManager;
  // public data: object[];
  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public filterOptions: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public selectionOptions: SelectionSettingsModel;
  public pageSettings;
  constructor(private companyService: CompanyService, private router: Router) { }
  public gridColumns = [
    {
      field: 'id', text: 'Id', primaryKey: true, format: '', type: 'text', editable: false, filterable: true, groupable: false,
      editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    },
    {
      field: 'name', text: 'Name', primaryKey: false, format: '', type: 'text', editable: true, filterable: true, groupable: false,
      editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    },
    {
      field: 'location', text: 'Location', primaryKey: false, format: '', type: 'text', editable: true, filterable: true,
      groupable: false, editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    },
    {
      field: 'tin', text: 'Tin', primaryKey: false, format: '', type: 'text', editable: true, filterable: true, groupable: false,
      editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    }
  ];
  ngOnInit() {


    this.data = new DataManager({
      url: 'http://localhost:53267/api/organizations',
      adaptor: new WebApiAdaptor(),
      updateUrl: 'api/organization',
      insertUrl: 'api/organization',
      removeUrl: 'api/organization'
    });

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
      'ColumnChooser',
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
    if (args.item.id === 'Grid_PdfExport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'Grid_ExcelExport') {
      this.grid.excelExport();
    } else if (args.item.id === 'Grid_add') {
      // this.router.navigate(['add/organization']);
    } else if (args.item.id === 'Grid_edit') {
      // this.router.navigate(['update/organization']);
    } else if (args.item.id === 'Grid_delete') {
    }


  }
}


