import { Component, OnInit, ViewChild } from '@angular/core';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { DataManager, WebApiAdaptor, UrlAdaptor } from '@syncfusion/ej2-data';
import {
  GroupSettingsModel, FilterSettingsModel, ToolbarItems,
  TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel, PageSettingsModel
} from '@syncfusion/ej2-grids';
import { Router } from '@angular/router';

import { CalanderService, CalanderPeriod } from '../calander.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-calander-view',
  templateUrl: './calander-view.component.html',
  styleUrls: ['./calander-view.component.css']
})
export class CalanderViewComponent implements OnInit {

  title = 'Fiscal Calander Period';

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

  constructor(private router: Router, private calanderService: CalanderService) { }

  public gridColumns = [
    {
      field: 'Id', text: 'Id', primaryKey: true, format: '',
      editable: false, filterable: true, groupable: false,
      type: 'number', editType: '', width: '50px'
    },
    {
      field: 'Start', text: 'Start', primaryKey: false, format: 'yMd',
      editable: true, filterable: true, groupable: false,
      type: 'datetime', editType: 'datepickeredit', width: '100px'
    },
    {
      field: 'End', text: 'End', primaryKey: false, format: 'yMd',
      editable: true, filterable: true, groupable: false,
      type: 'datetime', editType: 'datepickeredit', width: '100px'
    },
    {
      field: 'Active', text: 'Active', primaryKey: false, format: '',
      type: 'boolean', editable: true, filterable: true, groupable: false,
      editType: 'booleanedit', width: '50px'
    }
  ];

  ngOnInit() {
    this.data = new DataManager({
      url: 'http://localhost:53267/api/calanders',
      updateUrl: 'http://localhost:53267/api/calanders',
      insertUrl: 'http://localhost:53267/api/calanders',
      removeUrl: 'http://localhost:53267/api/calanders',
      adaptor: new WebApiAdaptor
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
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
  }

  handleError(error: HttpErrorResponse) {
    console.log(error);
  }

  // Click handler for when the toolbar is cliked
  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'calander_pdfexport') {
      this.grid.pdfExport();                            // when pdf export call grid prdfexport function
    } else if (args.item.id === 'calander_excelexport') {
      this.grid.excelExport();        // when excel export call grid excelexport function
    } else if (args.item.id === 'calander_add') {
      this.router.navigate(['calanders/new']);   // when user click add route to the calander form
    } else if (args.item.id === 'calander_edit') {

    } else if (args.item.id === 'calander_print') {
      this.grid.print();      // when the user click print print the current page
    }


  }

}
