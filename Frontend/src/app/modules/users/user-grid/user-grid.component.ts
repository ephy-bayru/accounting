import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
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

  ToolbarService,
  PdfExportService,
  CommandModel

} from '@syncfusion/ej2-ng-grids';
import { SmartAppConfigService } from '../../../smart-app-config.service';

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
    private router: Router,
    private appConfig: SmartAppConfigService
  ) {
  }
  ngOnInit() {
    // this.usersService.getUsers().subscribe((success: Users[]) => {
    //   this.data = success;
    // });
    this.data = new DataManager({
      url: 'http://localhost:53267/api/employees',
      adaptor: new WebApiAdaptor
    });
    this.initialPage = { pageCount: 5, pageSizes: true };
    this.groupOptions = { showGroupedColumn: true };
    this.filterSettings = { type: 'Menu' };
    this.toolbar = ['Add', 'Edit', 'Cancel', 'Search', 'Print', 'ExcelExport', 'PdfExport'];
    this.selectOptions = { type: 'Multiple', persistSelection: true };
    this.wrapSettings = { wrapMode: 'Content' };
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, showDeleteConfirmDialog: true, mode: 'Normal' };
    this.selectionOptions = { mode: 'Both', type: 'Single' };
    this.commands = [
      { type: 'Delete', buttonOption: { iconCss: 'e-icons e-delete', cssClass: 'e-flat' } }
    ];

  }
  toolbarClick(args: ClickEventArgs): void {

    if (args.item.id === 'employee_add') {
      this.router.navigate(['add/employee']);
    } else if (args.item.id === 'employee_edit') {
      const selectedemp: Object = this.grid.getSelectedRecords();
      this.router.navigate(['update/employee', selectedemp[0]['id']]);
    } else if (args.item.id === 'employee_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'employee_excelexport') {

      this.grid.excelExport(this.appConfig.EXCEL_EXPORT_PROPERTY);
    }

  }
}

