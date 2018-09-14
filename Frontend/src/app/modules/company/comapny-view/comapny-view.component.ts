import { Component, OnInit, ViewChild } from '@angular/core';
import { ToolbarItems, PageSettingsModel } from '@syncfusion/ej2-ng-grids';
import { ClickEventArgs } from '@syncfusion/ej2-ng-navigations';
import {
  GroupSettingsModel,
  FilterSettingsModel,
  EditSettingsModel,
  TextWrapSettingsModel,
  GridComponent,
  SelectionSettingsModel,
} from '@syncfusion/ej2-ng-grids';
import { Router } from '@angular/router';
import { WebApiAdaptor, DataManager, Query, ReturnOption, ODataV4Adaptor, JsonAdaptor, UrlAdaptor } from '@syncfusion/ej2-data';
import { CompanyService } from '../company.service';

@Component({
  selector: 'app-company-view',
  templateUrl: './comapny-view.component.html',
  styleUrls: ['./comapny-view.component.css']
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
  public filterOptions: FilterSettingsModel;

  constructor(private router: Router, private companyService: CompanyService) { }

  public gridColumns = [
    {
      field: 'id', text: 'Id', primaryKey: true, format: '',
      type: 'number', editable: false, filterable: true, groupable: false,
      editType: ''
    },
    {
      field: 'name', text: 'Name', primaryKey: false, format: '',
      type: 'string', editable: true, filterable: true, groupable: false,
      editType: 'textbox'
    },
    {
      field: 'location', text: 'Location', primaryKey: false, format: '',
      type: 'string', editable: true, filterable: true, groupable: false,
      editType: 'textbox'
    },
    {
      field: 'tin', text: 'Tin', primaryKey: false, format: '',
      type: 'string', editable: true, filterable: true, groupable: false,
      editType: 'textbox'
    }
  ];


  columnMenuOpen(arg) {
    console.log(`${arg} column menu open`);
  }
  columnMenuClick(arg) {
    console.log(`${arg} column menu Click`);
  }
  ngOnInit() {

  this.companyService.getOrganizationsList().subscribe((success: any) => {
      this.data = success;
    });

    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.selectionOptions = { type: 'Single' }; // allow only single row to be selected at a time for edit or delete
    this.groupOptions = { showGroupedColumn: true }; // make columns used for grouping visable
    this.toolbarOptions = [
      'Add',
      'Edit',
      'Delete',
      'Print',
      'PdfExport',
      'ExcelExport',
      'Search'
    ];

    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
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


