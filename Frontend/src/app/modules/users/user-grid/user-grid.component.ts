import { Component, OnInit, ViewChild } from '@angular/core';
import { UsersService } from './../users.service';
import { ClickEventArgs } from '@syncfusion/ej2-ng-navigations';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import { Router } from '@angular/router';
import { Users } from '../users';
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
  PdfExportService

} from '@syncfusion/ej2-ng-grids';

@Component({
  selector: 'app-user-grid',
  templateUrl: './user-grid.component.html',
  styleUrls: ['./user-grid.component.css'],
  providers: [ToolbarService, PdfExportService]
})
export class UserGridComponent implements OnInit {
  title = 'Users Data';
  @ViewChild('grid')
  SERVICE_URI: 'users';

  public grid: GridComponent;
  public data: Users[] = [];

  public editSettings: EditSettingsModel;
  public filterSettings: FilterSettingsModel;
  public filterOptions: FilterSettingsModel;
  public toolbar: ToolbarItems[];
  public toolbarOptions: ToolbarItems[];
  public groupOptions: GroupSettingsModel;
  public wrapSettings: TextWrapSettingsModel;
  public pageSettings: PageSettingsModel;
  public selectionOptions: SelectionSettingsModel;


  constructor(private router: Router, private usersService: UsersService) { }

  ngOnInit() {
    this.filterOptions = {
      type: 'Menu'
    };
    this.toolbarOptions = [
      'Add',
      'Edit',
      'Delete',
      'Print',
      'PdfExport',
      'WordExport',
      'ExcelExport',
      'Search'
    ];

    this.editSettings = {
      allowEditing: true,
      allowAdding: true,
      allowDeleting: true,
    };

    this.pageSettings = { pageSize: 10 };
    this.groupOptions = { showGroupedColumn: true };
    this.wrapSettings = { wrapMode: 'Content' };
    this.selectionOptions = { mode: 'Both', type: 'Single' };

    this.usersService.getUsers().subscribe((success: Users[]) => {
      this.data = success;
    });

    // adaptor: new WebApiAdaptor(),
    // crossDomain: true,
    // enableCaching: true,
    // cachingPageSize: 10,
    // timeTillExpiration: 100000
  }

  columnMenuOpen(arg) {
    console.log(`${arg} column menu open`);
  }
  columnMenuClick(arg) {
    console.log(`${arg} column menu Click`);
  }

  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'add-user') {
      this.router.navigate(['add/user']);
    } else if (args.item.id === 'edit-user') {
      const selecteduser: Object = this.grid.getSelectedRecords();
      this.router.navigate(['update/user/id'], selecteduser);
    } else if (args.item.id === 'employee_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'employee_excelexport') {
      this.grid.excelExport();
    }
  }
}

