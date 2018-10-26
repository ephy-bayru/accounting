import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ExchangeRateService } from '../exchange_rate.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Exchangerate } from '../exchange_rate';

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

  public disable: false;
  statusCode: any;

  constructor(
    private exRateService: ExchangeRateService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) { }

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
        Date: ['', Validators.required]
      });
  }

  xrateModel(exRateForm: FormGroup): Exchangerate {
    const exrate = exRateForm.value;
    const xrateData: Exchangerate = new Exchangerate;
    xrateData.id = exrate.id;
    xrateData.BuyRate = exrate.BuyRate;
    xrateData.SaleRate = exrate.SaleRate;
    xrateData.Date = exrate.Date;
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
