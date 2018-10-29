import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CurrencyService } from './../currency.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Currency } from './../currency';

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
        symbols: ['', Validators.required],
        country: ''
      });
  }

  currencyModel(currencyForm: FormGroup): Currency {
    const crncy = currencyForm.value;
    const currencyData: Currency = new Currency;
    currencyData.id = crncy.id;
    currencyData.name = crncy.name;
    currencyData.abrevation = crncy.abrevation;
    currencyData.symbol = crncy.symbol;
    currencyData.country = crncy.country;
    return currencyData;
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
