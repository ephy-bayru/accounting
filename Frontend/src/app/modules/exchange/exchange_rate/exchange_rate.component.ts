import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ExchangeRateService } from '../exchange_rate.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Exchangerate } from '../exchange_rate';
import { Query, DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-currency',
  templateUrl: './exchange_rate.component.html',
  styleUrls: ['./exchange_rate.component.css']
})
export class ExchangerateComponent implements OnInit {
  exRateForm: FormGroup;
  Exchangerate: Exchangerate;
  id: number;
  id_no: number;
   // set the placeholder to DropDownList input element
  public CurrencyWaterMark: 'Select Currency';
  public disable: false;
  statusCode: any;

  constructor(
    private exRateService: ExchangeRateService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) { }
   // bind the DataManager instance to dataSource property
  public data: DataManager = new DataManager({
    url: 'http://localhost:53267/api/currency',
    adaptor: new WebApiAdaptor,
    crossDomain: true
});
 // bind the Query instance to query property
 public query: Query = new Query().select(['name', 'ID']);
 // maps the remote data column to fields property
 public xrateFields: Object = { text: 'name', value: 'ID' };

  ngOnInit(): void {
    this.xRateForm();
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      this.exRateService.getRate(this.id)
        .subscribe(
          (exchangeRate: Exchangerate) => this.xRateForm(Exchangerate));
    }
  }

  // ─── INITIALIZING EXCHANGE RATE FORM ───────────
  xRateForm(Exrate: any = '') {
    this.exRateForm = this
      .fb
      .group({
        BuyRate: ['', Validators.required],
        SaleRate: ['', Validators.required],
        Date: ['', Validators.required],
        Currency: ['', Validators.required]
      });
  }

  xrateModel(exRateForm: FormGroup): Exchangerate {
    const exrate = exRateForm.value;
    const xrateData: Exchangerate = new Exchangerate;
    xrateData.id = exrate.id;
    xrateData.BuyRate = exrate.BuyRate;
    xrateData.SaleRate = exrate.SaleRate;
    xrateData.Date = exrate.Date;
    xrateData.Currency = exrate.Currency;
    return xrateData;
  }

  onSubmit() {
    const exrate = this.xrateModel(this.exRateForm);
    if (this.id) {
      this.exRateService.updateRate(exrate, this.id)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        },
          errorCode => this.statusCode = errorCode);
    } else {
      this.exRateService.addRate(exrate)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        },
          errorCode => this.statusCode = errorCode);
    }
  }

  onCancel() {
    this.location.back();
  }

}
