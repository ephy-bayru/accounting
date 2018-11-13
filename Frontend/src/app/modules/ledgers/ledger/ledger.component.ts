import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, AbstractControl, ValidatorFn } from '@angular/forms';
import { LedgerService, Ledger } from '../ledger.service';
import { Location } from '@angular/common';
import { Query, DataManager, WebApiAdaptor, ReturnOption } from '@syncfusion/ej2-data';
import { HttpErrorResponse } from '@angular/common/http';

function balanceChecker(): ValidatorFn {

  return (c: AbstractControl): { [key: string]: boolean } | null => {
    let amountSum = 0;
    this.accounts.controls.forEach(element => {
      amountSum += element.Amouunt;
    });

    if (amountSum === 0) {
      return null;
    }

    return { 'balanceNotEqual': true };
  };

}


@Component({
  selector: 'app-ledger',
  templateUrl: './ledger.component.html',
  styleUrls: ['./ledger.component.css']
})
export class LedgerComponent implements OnInit {

  public ledgerForm: FormGroup;
  public accountList: Object[];
  public isEqual: Boolean = true;
  public accountForm: FormGroup;
  public accountQuery: Query;
  public amountSum = 0;
  public accountFields: Object;
  constructor(private formBuilder: FormBuilder,
    private ledgerService: LedgerService,
    private location: Location) {
    this.createForm();

    this.accountQuery = new Query().select(['Name', 'AccountId']);
    this.accountFields = { text: 'Name', value: 'AccountId' };
  }

  ngOnInit() {

    this.accountQuery = new Query().select(['AccountName', 'AccountId']);
    this.accountFields = { text: 'AccountName', value: 'AccountId' };


    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);

    this.accounts.valueChanges.subscribe(value => {
      this.amountSum = 0;

      value.forEach(element => {
        this.amountSum += element.Amount;
      });
      if (this.amountSum === 0) {
        this.isEqual = true;

        this.accounts.controls.forEach(c => c.clearValidators());
      } else {
        this.isEqual = false;
        this.accounts.controls.forEach(c => c.setValidators(balanceChecker));
      }

    });
  }
  logError(error) {
    console.log(error);
  }
  createForm(data: any = '') {
    this.ledgerForm = this.formBuilder.group({
      description: ['', [Validators.required]],
      date: ['', Validators.required],
      accounts: this.formBuilder.array([
        this.formBuilder.group({
          AccountId: [(data.AccountId) ? data.AccountId : '', Validators.required],
          Amount: [(data.Amount) ? data.Amount : 0, Validators.required],
          Reference: [(data.Reference) ? data.Reference : '']
        }),
        this.formBuilder.group({
          AccountId: [(data.AccountId) ? data.AccountId : '', Validators.required],
          Amount: [(data.Amount) ? data.Amount : 0, Validators.required],
          Reference: [(data.Reference) ? data.Reference : '']
        })])

    });
  }

  onCancel() {
    this.location.back();
  }

  onSubmit() {
    const formData = this.prepareData(this.ledgerForm);
    console.log(formData);
    this.ledgerService.addLedgerEntry(formData).subscribe(
      (data: Ledger) => {
        alert('Ledger entry made successfully');
      },
      (error: HttpErrorResponse) => console.log(error)
    );

  }

  removeRow(index: number) {
    this.accounts.removeAt(index);

  }
  prepareData(data: FormGroup): Ledger {
    const form = data.value;

    const ledger = new Ledger();
    ledger.createdOn = form.date;
    ledger.description = form.description;

    this.accounts.controls.forEach(element => {
      ledger.jornal.push({
        amount: (element.get('Amount').value) ? element.get('Amount').value : 0,
        accountId: element.get('AccountId').value,
        reference: (element.get('Reference').value) ? element.get('Reference').value : 0,
      });
    });
    return ledger;
  }
  get accounts(): FormArray {
    return this.ledgerForm.get('accounts') as FormArray;
  }

  addForm() {
    this.accounts.push(this.formBuilder.group({
      AccountId: ['', Validators.required],
      Amount: [0, Validators.required],
      Reference: [''],
    }));

  }
}
