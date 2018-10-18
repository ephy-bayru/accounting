import { Component, OnInit, ViewChild } from '@angular/core';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { DataManager, WebApiAdaptor, UrlAdaptor } from '@syncfusion/ej2-data';
import {
  GroupSettingsModel, FilterSettingsModel, ToolbarItems,
  TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel,
  PageSettingsModel, CommandModel, ExcelExportProperties, EditEventArgs, RowDeselectEventArgs
} from '@syncfusion/ej2-grids';
import { Router, ActivatedRoute } from '@angular/router';

import { CalanderService, CalanderPeriod } from '../calander.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SmartAppConfigService } from '../../../smart-app-config.service';

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
  public excelExportProperties: ExcelExportProperties;
  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public selectionOptions: SelectionSettingsModel;
  public pageSettings: PageSettingsModel;
  public filterOptions: FilterSettingsModel;
  public commands: CommandModel[];
  public isUpdate: Boolean = false;

  constructor(private router: Router,
    private calanderService: CalanderService,
    private appConfig: SmartAppConfigService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {


    this.data = new DataManager({
      url: 'http://localhost:53267/api/calanders',
      adaptor: new WebApiAdaptor,
      offline: true
    });


    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.selectionOptions = { type: 'Single' }; // allow only single row to be selected at a time for edit or delete
    this.groupOptions = { showGroupedColumn: true }; // make columns used for grouping visable
    this.toolbarOptions = [
      'Add',
      'Print',
      'PdfExport',
      'ExcelExport',
      'Search'
    ];
    this.commands = [
      { type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editCalender.bind(this) } },
      { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];
    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: false, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
  }

  editCalender(data) {
    console.log(data);
    this.router.navigate(['calanders/update']);
  }
  handleError(error: HttpErrorResponse) {
    console.log(error);
  }

  // Click handler for when the toolbar is cliked
  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'calander_pdfexport') {
      this.grid.pdfExport(this.appConfig.PDF_EXPORT_PROPERTY);   // when pdf export call grid prdfexport function
    } else if (args.item.id === 'calander_excelexport') {
      this.grid.excelExport(this.appConfig.EXCEL_EXPORT_PROPERTY);        // when excel export call grid excelexport function
    } else if (args.item.id === 'calander_add') {
      this.router.navigate(['calanders/new']);   // when user click add route to the calander form
    } else if (args.item.id === 'calander_edit') {
      this.router.navigate(['calanders/update']);
    } else if (args.item.id === 'calander_print') {
      this.grid.print();      // when the user click print print the current page
    }


  }

}
