import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { ClickEventArgs } from '@syncfusion/ej2-ng-navigations';
import { DataManager, WebApiAdaptor, Adaptor } from '@syncfusion/ej2-data';
import { Router } from '@angular/router';
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
  selector: 'app-exrate-grid',
  templateUrl: './exchange-rate-grid.component.html',
  styleUrls: ['./exchange-rate-grid.component.css'],
  providers: [ToolbarService, PdfExportService],
  encapsulation: ViewEncapsulation.None
})
export class ExRateGridComponent implements OnInit {
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
    private router: Router,
    private appConfig: SmartAppConfigService
  ) {
  }
  ngOnInit() {
    this.data = new DataManager({
      url: 'http://localhost:53267/api/xrate',
      adaptor: new WebApiAdaptor
    });
    this.initialPage = { pageCount: 5, pageSizes: true };
    this.groupOptions = { showGroupedColumn: true };
    this.filterSettings = { type: 'Menu' };
    this.toolbar = ['Add', 'Edit', 'Cancel', 'Search', 'Print', 'ExcelExport', 'PdfExport'];
    this.selectOptions = { type: 'Multiple', persistSelection: true };
    this.editSettings = { allowDeleting: true };
    this.wrapSettings = { wrapMode: 'Content' };
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, showDeleteConfirmDialog: true, mode: 'Normal' };
    this.selectionOptions = { mode: 'Both', type: 'Single' };
    this.commands = [
      { type: 'Delete', buttonOption: { iconCss: 'e-icons e-delete', cssClass: 'e-flat' } }
    ];

  }
  toolbarClick(args: ClickEventArgs): void {

      if (args.item.id === 'exrate_add') {
        this.router.navigate(['add/exrate']);
      } else if (args.item.id === 'exrate_edit') {
        const selectedcur: Object = this.grid.getSelectedRecords();
        this.router.navigate(['update/exrate', selectedcur[0]['id']]);
      } else if (args.item.id === 'exrate_pdfexport') {
        this.grid.pdfExport();
      } else if (args.item.id === 'exrate_excelexport') {

        this.grid.excelExport(this.appConfig.EXCEL_EXPORT_PROPERTY);
      }

    }
  }

