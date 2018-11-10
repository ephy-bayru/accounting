import { Component, OnInit, ViewChild } from '@angular/core';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import {
  GridComponent, ExcelExportProperties, GroupSettingsModel,
  FilterSettingsModel, ToolbarItems, TextWrapSettingsModel, EditSettingsModel,
  SelectionSettingsModel, PageSettingsModel, CommandModel, RowSelectEventArgs, GridModel
} from '@syncfusion/ej2-ng-grids';
import { Router } from '@angular/router';
import { AccountsService } from '../accounts.service';
import { SmartAppConfigService } from '../../../smart-app-config.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';


@Component({
  selector: 'app-accounts-view',
  templateUrl: './accounts-view.component.html',
  styleUrls: ['./accounts-view.component.css']
})
export class AccountsViewComponent implements OnInit {

  title = 'Fiscal Calander Period';

  @ViewChild('grid')
  public grid: GridComponent;
  public data: DataManager;
  public excelExportProperties: ExcelExportProperties;
  public filterSettings: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public selectionOptions: SelectionSettingsModel;
  public pageSettings: PageSettingsModel;
  public filterOptions: FilterSettingsModel;
  public commands: CommandModel[];
  public groupOptions: GroupSettingsModel = { showDropArea: false};

  public childGrid: GridModel;
  constructor(private router: Router, private calanderService: AccountsService, private appConfig: SmartAppConfigService) { }

  ngOnInit() {

    this.data = new DataManager({
      url: 'http://localhost:53267/api/accounts',
      adaptor: new WebApiAdaptor,
      offline: true
    });

    this.childGrid  = {
      dataSource: this.data,
      queryString: 'ParentAccount',
      columns: [
          { field: 'AccountId', headerText: 'Account Id', textAlign: 'Right', width: 120 },
          { field: 'AccountName', headerText: 'Name', width: 150 },
          { field: 'TotalAmount', headerText: 'TotalAmount', width: 150 },
          { field: 'Active', headerText: 'Status', width: 150 },
          { field: 'ParentAccount', headerText: 'Parent', width: 150 }


      ],
  };

    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.selectionOptions = { type: 'Single' }; // allow only single row to be selected at a time for edit or delete

    this.toolbarOptions = [
      'Add',
      'Print',
      'PdfExport',
      'ExcelExport',
      'Search'
    ];
    this.commands = [
      { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];
    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
  }

  handleError(error: HttpErrorResponse) {
    console.log(error);
  }

  rowSelected(args: RowSelectEventArgs) {
    if (args.data['AccountId']) {
      this.router.navigate([`accounts/update/${args.data['AccountId']}`]);
    }
  }
  onDataBound() {
    this.grid.detailRowModule.expandAll();
  }
  // Click handler for when the toolbar is cliked
  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'accounts_pdfexport') {
      this.grid.pdfExport(this.appConfig.PDF_EXPORT_PROPERTY);   // when pdf export call grid prdfexport function
    } else if (args.item.id === 'accounts_excelexport') {
      this.grid.excelExport(this.appConfig.EXCEL_EXPORT_PROPERTY);        // when excel export call grid excelexport function
    } else if (args.item.id === 'accounts_add') {
      this.router.navigate(['accounts/new']);   // when user click add route to the accounts form
    } else if (args.item.id === 'accounts_edit') {

    } else if (args.item.id === 'accounts_print') {
      this.grid.print();      // when the user click print print the current page
    }


  }


}
