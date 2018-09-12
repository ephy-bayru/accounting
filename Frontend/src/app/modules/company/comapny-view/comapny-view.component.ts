import { Component, OnInit, ViewChild } from '@angular/core';
import { ToolbarItems, PageSettingsModel } from '@syncfusion/ej2-ng-grids';
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
  title = 'Company Profile';

  @ViewChild('grid')
  public grid: GridComponent;
  public data: DataManager;
  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public selectionOptions: SelectionSettingsModel;
  public pageSettings: PageSettingsModel;

  constructor(
    private router: Router) { }

  public gridColumns = [
    {
      field: 'id', text: 'Id', primaryKey: true, format: '',
      type: 'text', editable: false, filterable: true, groupable: false,
      editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    },
    {
      field: 'name', text: 'Name', primaryKey: false, format: '',
      type: 'text', editable: true, filterable: true, groupable: false,
      editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    },
    {
      field: 'location', text: 'Location', primaryKey: false, format: '',
      type: 'text', editable: true, filterable: true, groupable: false,
      editType: '', foreignKey: false, foreignKeyValue: '', frozen: false
    },
    {
      field: 'tin', text: 'Tin', primaryKey: false, format: '',
      type: 'text', editable: true, filterable: true, groupable: false,
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
    this.selectionOptions = { type: 'Single' };
    this.groupOptions = { showGroupedColumn: true };
    this.filterSettings = { type: 'CheckBox' };
    this.wrapSettings = { wrapMode: 'Content' };
    this.toolbarOptions = [
      'Add',
      'Edit',
      'Delete',
      'Print',
      'PdfExport',
      'ExcelExport',
      'ColumnChooser',
      'Search'
    ];
    this.pageSettings = { pageSize: 4 };
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.selectionOptions = { mode: 'Both' };
  }


  // Click handler for when the toolbar is cliked
  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'organization_pdfexport') {
      this.grid.pdfExport();                            // when pdf export call grid prdfexport function
    } else if (args.item.id === 'organization_excelexport') {
      this.grid.excelExport();        // when excel export call grid excelexport function
    } else if (args.item.id === 'organization_add') {
      this.router.navigate(['add/organization']);   // when user click add route to the organization form
    } else if (args.item.id === 'organization_edit') {

      const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();
      const selectedrecords: Object = this.grid.getSelectedRecords();
      this.router.navigate(['update/organization', selectedrecords[0]['id']]); // when user click update route to the organization

    } else if (args.item.id === 'organization_print') {
      this.grid.print();      // when the user click print print the current page
    }


  }

}


