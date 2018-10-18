import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { LedgerService } from '../ledger.service';
import { Location } from '@angular/common';
import { Query, DataManager, WebApiAdaptor, ReturnOption } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-ledger',
  templateUrl: './ledger.component.html',
  styleUrls: ['./ledger.component.css']
})
export class LedgerComponent implements OnInit {

  public ledgerForm: FormGroup;
  public accountList: Object[];
  public accountForm: FormGroup;
  public accountQuery: Query;

  public accountFields: Object;
  constructor(private formBuilder: FormBuilder,
    private ledgerService: LedgerService,
    private location: Location) {
      this.createForm();
     }

  ngOnInit() {

    this.accountQuery = new Query().select(['AccountCode', 'AccountId']);
    this.accountFields = { text: 'AccountId', value: 'AccountId' };


    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);
  }

  createForm(data: any = '') {
    this.ledgerForm = this.formBuilder.group({
      description: ['', [Validators.required]],
      date: ['', Validators.required],
      accounts: this.formBuilder.array([
        this.formBuilder.group({
          AccountId: [data.AccountId, Validators.required],
          Credit: [data.AccountType, Validators.required],
          Debit: [data.Name, Validators.required],
          Reference: [(data.Active) ? data.Active : false],
        }),
        this.formBuilder.group({
          AccountId: [data.AccountId, Validators.required],
          Credit: [data.AccountType, Validators.required],
          Debit: [data.Name, Validators.required],
          Reference: [(data.Active) ? data.Active : false],
        })])

    });
  }

  get accounts(): FormArray {
    return this.ledgerForm.get('accounts') as FormArray;
  }

  addForm() {
    this.accounts.push(this.formBuilder.group({
      AccountId: ['', Validators.required],
      Credit: ['', Validators.required],
      Debit: ['', Validators.required],
      Reference: [''],
    }));
  }
}
