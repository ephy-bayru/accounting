import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { AccountsService } from '../accounts.service';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { DataManager, WebApiAdaptor, ReturnOption, Query } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})


export class AccountsComponent implements OnInit {
  public accountList: Object[];
  public organizationList: Object[];
  public accountForm: FormGroup;
  public accountQuery: Query;
  public accountFields: Object;
  public organizationQuery: Query;
  public organizationFields: Object;
  public accountTypes: Object = ['ASSET', 'LIABLITY', 'REVENUE', 'EXPENSE', 'INCOME'];
  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder, private account: AccountsService) {
    this.createForm();
  }

  ngOnInit() {
    this.accountQuery = new Query().select(['AccountCode', 'AccountId']);
    this.accountFields = { text: 'AccountId', value: 'AccountId' };
    this.organizationQuery = new Query().select(['name', 'id']);
    this.organizationFields = {text: 'name', value: 'id'};

    const orgDm: DataManager = new DataManager(
      {url: 'http://localhost:53267/api/organizations', adaptor: new WebApiAdaptor, offline: true},
      new Query().take(5)
    );
    orgDm.ready.then((e: ReturnOption) => this.organizationList = <Object[]>e.result).catch((e) => true);

    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);
  }

  dateSelected(date: Object) {

  }
  createForm() {
    this.accountForm = this.formBuilder.group({
      accounts: this.formBuilder.array([
        this.formBuilder.group({
          accountCode: ['', Validators.required],
          AccountId: '',
          accountType: ['', Validators.required],
          Name: ['', Validators.required],
          active: [false],
          OpeningBalance: 0,
          organizationId: ['', Validators]
        })])

    });
  }

  addPeriod() {
    this.accounts.push(this.formBuilder.group({
      accountCode: ['', Validators.required],
      accountId: '',
      Name: ['', Validators.required],
      active: [false],
      accountType: ['', Validators.required],
      OpeningBalance: 0,
      organizationId: ['', Validators.required]
    }));
  }

  get accounts(): FormArray {
    return this.accountForm.get('accounts') as FormArray;
  }

  onSubmit() {
    this.account.createAccountPeriod(this.accountForm.value['accounts']).subscribe(result => console.log(result));
  }

  btnClick() {
    if (this.statusBtn.element.classList.contains('e-active')) {
      this.statusBtn.content = 'Deactiveated';
      this.statusBtn.iconCss = 'e-icons e-pause-icon';
      this.statusBtn.element.classList.remove('e-success');
      this.statusBtn.element.classList.remove('e-warning');
    } else {
      this.statusBtn.content = 'Active';
      this.statusBtn.iconCss = 'e-icons e-play-icon';
      this.statusBtn.element.classList.remove('e-warning');
      this.statusBtn.element.classList.add('e-success');
    }
  }

}
