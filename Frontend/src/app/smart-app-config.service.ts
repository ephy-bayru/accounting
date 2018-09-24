import { Injectable } from '@angular/core';
import { ExcelExportProperties } from '@syncfusion/ej2-grids';

@Injectable()
export class SmartAppConfigService {

  public EXCEL_EXPORT_PROPERTY: ExcelExportProperties = {
    fileName: 'SmartAccounting.xlsx',
    dataSource: Object,
    header: {
      headerRows: 7,
      rows: [
        {
          cells: [
            {
              colSpan: 5,
              value: 'AppDiv Smart Accounting ',
              style: { fontColor: '#C67878', fontSize: 20, hAlign: 'Center', bold: true }
            }
          ]
        },
        {
          cells: [
            {
              colSpan: 4,
              value: 'Addis Ababa, Ethiopia',
              style: { fontColor: '#C67878', fontSize: 15, hAlign: 'Center', bold: true }
            }
          ]
        },
        {
          cells: [
            {
              colSpan: 5,
              value: 'Tel +251 912 669988',
              style: { fontColor: '#C67878', fontSize: 15, hAlign: 'Center', bold: true }
            }
          ]
        },
        {
          cells: [
            {
              colSpan: 5,
              hyperlink: { target: 'https://www.appdiv.com/', displayText: 'www.appdiv.com' },
              style: { hAlign: 'Center' }
            }
          ]
        },
        {
          cells: [
            {
              colSpan: 5,
              hyperlink: { target: 'mailto:raju@gmail.com' },
              style: { hAlign: 'Center' }
            }
          ]
        },
      ]
    },
    footer: {
      footerRows: 5,
      rows: [
        {
          cells: [
            {
              colSpan: 5,
              value: 'Thank you for using our system!!',
              style: { hAlign: 'Center', bold: true }
            }
          ]
        },
        {
          cells: [
            {
              colSpan: 5,
              value: '!Send Use your feedbacks!',
              style: { hAlign: 'Center', bold: true }
            }
          ]
        }
      ]
    },
  };
  constructor() { }
}
