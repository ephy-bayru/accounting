import { Component, OnInit, ViewChild } from '@angular/core';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { GroupSettingsModel, FilterSettingsModel, CommandModel,
  TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel } from '@syncfusion/ej2-grids';
import { Router } from '@angular/router';
import { SmartAppConfigService } from '../../../smart-app-config.service';
import { LedgerService } from '../ledger.service';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

@Component({
  selector: 'app-ledger-view',
  templateUrl: './ledger-view.component.html',
  styleUrls: ['./ledger-view.component.css']
})
export class LedgerViewComponent implements OnInit {
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
    private ledgerService: LedgerService,
    private router: Router,
    private appConfig: SmartAppConfigService
  ) {
  }
  ngOnInit() {
    this.data = new DataManager({
      url: 'http://localhost:53267/api/ledger',
      adaptor: new WebApiAdaptor,
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
    if (args.item.id === 'ledger_add') {
      this.router.navigate(['ledgers/entry']);
    } else if (args.item.id === 'ledger_edit') {
      const selectedcust: Object = this.grid.getSelectedRecords();
      this.router.navigate(['ledgers/entry', selectedcust[0]['id']]);
    } else if (args.item.id === 'ledger_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'ledger_excelexport') {
      this.grid.excelExport(this.appConfig.EXCEL_EXPORT_PROPERTY);
    }

  }

}
