import { Component, OnInit, ViewChild, ViewEncapsulation  } from '@angular/core';
import { UsersService } from './../users.service';
import { ClickEventArgs } from '@syncfusion/ej2-ng-navigations';
import { DataManager, WebApiAdaptor, Adaptor } from '@syncfusion/ej2-data';
import { Router } from '@angular/router';

import { Users } from '../users';
import { Tooltip } from '@syncfusion/ej2-popups';
import {
  GridComponent,
  FilterSettingsModel,
  SelectionSettingsModel,
  GroupSettingsModel,
  EditSettingsModel,
  TextWrapSettingsModel,
  PageSettingsModel,
  ToolbarItems,
  ToolbarService,
  PdfExportService,
  CommandModel,
  QueryCellInfoEventArgs

} from '@syncfusion/ej2-ng-grids';

@Component({
  selector: 'app-user-grid',
  templateUrl: './user-grid.component.html',
  styleUrls: ['./user-grid.component.css'],
  providers: [ToolbarService, PdfExportService],
  encapsulation: ViewEncapsulation.None
})
export class UserGridComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  public data: DataManager;
  public initialPage: Object;

  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public toolbar: string[];
  public selectOptions: Object;
  public commands: CommandModel[];
  public wrapSettings: TextWrapSettingsModel;
  public editSettings: EditSettingsModel;
  public selectionOptions: SelectionSettingsModel;


  constructor(
     private usersService: UsersService,
     private router: Router
    ) {
 }
  ngOnInit() {
    // this.data = usersDAta;
    // this.usersService.getUsers().subscribe((success: Users[]) => {
    //   this.data = success;
    // });
    this.data = new DataManager({
      url: 'http://localhost:53267/api/employees',
      adaptor: new WebApiAdaptor
    });
    this.initialPage = {pageCount: 5,  pageSizes: true};
    this.groupOptions = { showGroupedColumn: true };
    this.filterSettings = { type: 'Menu' };
    this.toolbar = ['Add', 'Edit', 'Cancel', 'Search', 'Print', 'ExcelExport', 'PdfExport'];
    this.selectOptions = { type: 'Multiple',  persistSelection: true };
    this.editSettings = { allowDeleting: true };
    this.wrapSettings = { wrapMode: 'Content' };
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, showDeleteConfirmDialog: true, mode: 'Normal' };
    this.selectionOptions = { mode: 'Both', type: 'Single' };
    this.commands = [
    { type: 'Delete', buttonOption: { iconCss: 'e-icons e-delete', cssClass: 'e-flat'} },
    { type: 'Edit', buttonOption: { iconCss: ' e-icons e-edit', cssClass: 'e-flat' } },
   ];

  }
  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.text) {
        case 'PDF Export':
            this.grid.pdfExport();
            break;
        case 'Excel Export':
            this.grid.excelExport();
            break;
        case 'beginEdit':
           this.router.navigate(['users']);
           break;


      // if (args.item.id === 'add-user') {
      //   this.router.navigate(['add/user']);
      // } else if (args.item.id === 'edit-user') {
      //   const selecteduser: Object = this.grid.getSelectedRecords();
      //   this.router.navigate(['update/user/id'], selecteduser);
      // } else if (args.item.id === 'employee_pdfexport') {
      //   this.grid.pdfExport();
      // } else if (args.item.id === 'employee_excelexport') {
      //   this.grid.excelExport();
      // }
    }
  }
}
