import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup, FormControl, FormArray } from '@angular/forms';
import { CurrencyService } from './../currency.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Currency } from './../currency';
import { Query, DataManager, ODataAdaptor } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements OnInit {
  currencyForm: FormGroup;
  currency: Currency;
  id: number;
  id_no: number;
  public disable: false;
  statusCode: any;

  constructor(
    private currencyService: CurrencyService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) { }



  ngOnInit(): void {
    this.curencyForm();
    // this.AddxRate();
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      this.currencyService.getCurrency(this.id)
        .subscribe(
          (currency: Currency) => this.curencyForm(currency));
    }
  }

  // ─── INITIALIZING CURRENCY FORM ───────────
  curencyForm(Curency: any = '') {
    this.currencyForm = this
      .fb
      .group({
        name: ['', [Validators.required, Validators.minLength(2)]],
        abrevation: ['', Validators.required],
        symbol: ['', Validators.required],
        country: ['', Validators.required]
        // ExRate: this.fb.array([])
      });
  }
  get ExRate(): FormArray {
    return this.currencyForm.get('ExRate') as FormArray;
  }

  currencyModel(currencyForm: FormGroup): Currency {
    const crncy = currencyForm.value;
    const currencyData: Currency = new Currency;
    currencyData.id = crncy.id;
    currencyData.name = crncy.name;
    currencyData.abrevation = crncy.abrevation;
    currencyData.symbol = crncy.symbol;
    currencyData.country = crncy.country;
    // this.ExRate.controls.forEach(element => {
    //   const rate: ExchangeRate = new ExchangeRate();
    //   const xr = element.value;
    //   rate.id = xr.id;
    //   rate.BuyRate = xr.BuyRate;
    //   rate.SaleRate = xr.SaleRate;
    //   rate.Date = xr.Date;
    //   currencyData.ExRate.push(rate);
    // });
    return currencyData;
  }
  AddxRate() {
    this.ExRate.push(this.fb.group({
      BuyRate: ['', Validators.required],
      SaleRate: ['', Validators.required],
      Date: ['', Validators.required]
    }));
  }


  onSubmit() {
    const currency = this.currencyModel(this.currencyForm);
    if (this.id) {
      this.currencyService.updateCurrency(currency, this.id)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        },
          errorCode => this.statusCode = errorCode);
    } else {
      this.currencyService.addCurrency(currency)
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
