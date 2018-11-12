import { Component, OnInit, ViewChild } from '@angular/core';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { DataManager, WebApiAdaptor, UrlAdaptor } from '@syncfusion/ej2-data';
import {
  GroupSettingsModel, FilterSettingsModel, ToolbarItems,
  TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel,
  PageSettingsModel, CommandModel, ExcelExportProperties, EditEventArgs, RowDeselectEventArgs, Column, IRow
} from '@syncfusion/ej2-grids';
import { Router, ActivatedRoute } from '@angular/router';

import { CalanderService, CalanderPeriod } from '../calander.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SmartAppConfigService } from '../../../smart-app-config.service';
import { closest } from '@syncfusion/ej2-base';

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
  public onLabel = 'Yes';
  public offLabel = 'No';

  constructor(private router: Router,
    private calanderService: CalanderService,
    private appConfig: SmartAppConfigService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {


    this.data = new DataManager({
      url: 'http://localhost:53267/api/calanders',
      adaptor: new WebApiAdaptor,
      offline: false
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
    this.commands = [{
      buttonOption: {
        cssClass: 'e-flat e-large e-error', iconCss: 'e-delete e-icons', click: this.deletePeriod.bind(this)
      }
    }];
    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: false, allowAdding: true, allowDeleting: true };
  }
  /*
  called when user clicks
  deletes the requested row of period when used clicks
  */
  deletePeriod(args: any) {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    const data: Object = rowObj.data;

    this.calanderService.deleteCalanderPeriod(data['Id'])
      .subscribe((result: boolean) => alert('Period Deleted Successfuly'),
        this.handleError
      );
  }

  /*handels managing the event when the user clicks the active button
  to update the status of a given period
  */
  closeChanged(data: any, status: boolean): void {

    this.calanderService.updateCalanderPeriod(data.Id, {
      id: data.Id,
      Start: data.Start,
      End: data.End,
      Active: status,
      IsBegining: data.IsBegining
    }).subscribe(
      result => alert('Period Updated Successfuly'),
      this.handleError
    );

  }

  /*handels managing the event when the user clicks the Opening Period button
  to update wether a given period is an period opening or not
  */
  openingChanged(data: any, status: boolean): void {
    this.calanderService.updateCalanderPeriod(data.Id, {
      id: data.Id,
      Start: data.Start,
      End: data.End,
      Active: data.Active,
      IsBegining: status
    }).subscribe(
      result => alert('Period Updated Successfuly'),
      this.handleError
    );

  }



  // Click handler for when the toolbar is cliked
  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'calander_pdfexport':
        this.grid.pdfExport(this.appConfig.PDF_EXPORT_PROPERTY);   // when pdf export call grid prdfexport function
        break;
      case 'calander_excelexport':
        this.grid.excelExport(this.appConfig.EXCEL_EXPORT_PROPERTY);        // when excel export call grid excelexport function
        break;
      case 'calander_add':
        this.router.navigate(['calanders/new']);   // when user click add route to the calander form
        break;
      case 'calander_edit':
        this.router.navigate(['calanders/update']);
        break;
      case 'calander_print':
        this.grid.print();      // when the user click print print the current page
        break;
      default:
        break;
    }

  }


  /*
  Handeles Http Error Responces
  */
  private handleError(error: HttpErrorResponse) {

    if (error.error instanceof ErrorEvent) { // check if the error occured on the client side
      console.error(`Client Side Error Occured`);
    } else {
      /* if error occured on server side
      check the status code and display appropriate message
      */
      switch (error.status) {
        case 423: // check if request resource is deletable
          alert(`Can't delete period because it has been linked with other part of system data`);
          break;
        case 404: // check if the request resource was found
          alert('Period With Id Was Not Found');
          break;
        case 422:
          alert('Date Provided Overlaps with existing period date on the system');
          break;
        default:
          alert('Unknow Error Occured Please Try again Late');
          break;
      }

    }

  }

}
