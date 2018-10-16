import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { AccountsService } from '../accounts.service';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { DataManager, WebApiAdaptor, ReturnOption, Query } from '@syncfusion/ej2-data';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

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
  private accountId: string;
  public accountFields: Object;
  public organizationQuery: Query;
  public organizationFields: Object;
  public calendarQuery: Query;
  public calendarFields: Object;
  public periodList: Object[];

  public accountTypes: Object = ['ASSET', 'LIABILITY', 'REVENUE', 'EXPENCE', 'INCOME'];
  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder,
    private account: AccountsService,
    private location: Location,
    private activatedRoute: ActivatedRoute) {
    this.createForm();
  }

  ngOnInit() {
    this.accountId = this.activatedRoute.snapshot.paramMap.get('accountId');

    if (this.accountId != null) {
      this.account.getAccountById(this.accountId).subscribe(data => this.createForm(data));
    }
    this.accountQuery = new Query().select(['AccountCode', 'AccountId']);
    this.accountFields = { text: 'AccountId', value: 'AccountId' };
    this.organizationQuery = new Query().select(['name', 'id']);
    this.organizationFields = { text: 'name', value: 'id' };
    this.calendarQuery = new Query().select(['Period', 'Id']);
    this.calendarFields = { text: 'Period', value: 'Id' };

    const orgDm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/organizations', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(5)
    );
    orgDm.ready.then((e: ReturnOption) => this.organizationList = <Object[]>e.result).catch((e) => true);

    const periodDm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/calanders?type=OPEN', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(5)
    );
    periodDm.ready.then((e: ReturnOption) => this.periodList = <Object[]>e.result).catch((e) => true);

    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);
  }

  dateSelected(date: Object) {

  }
  createForm(data: any = '') {
    this.accountForm = this.formBuilder.group({
      accounts: this.formBuilder.array([
        this.formBuilder.group({
          periodId: '',
          AccountCode: [data.AccountCode],
          AccountId: [data.AccountId, Validators.required],
          AccountType: [data.AccountType, Validators.required],
          Name: [data.Name, Validators.required],
          Active: [(data.Active) ? data.Active : false],
          OpeningBalance: [0],
          OrganizationId: [data.OrganizationId, Validators.required]
        })])

    });
  }

  addPeriod() {
    this.accounts.push(this.formBuilder.group({
      AccountCode: [''],
      AccountId: ['', Validators.required]],
      periodId: '',
      Name: ['', Validators.required],
      Active: [false],
      AccountType: ['', Validators.required],
      OpeningBalance: [0],
      OrganizationId: ['', Validators.required]
    }));
  }

  get accounts(): FormArray {
    return this.accountForm.get('accounts') as FormArray;
  }

  onSubmit() {
    if (!this.accountId) {
      this.account.createAccount(this.accounts.value).subscribe((success) => {
        alert('Account Created Successfully');
        this.location.back();

      },
        (error: HttpErrorResponse) => {
          console.log(error);
          alert(error);
        });
    } else {
      this.account.updateAccount(this.accountId, this.accounts.value[0]).subscribe((success: Object) => {
        this.location.back();
        alert('Account Created Successfully');
      },
      (error: HttpErrorResponse) => {
        console.log(error);
        alert(error.message);
      });
    }
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

  cancel() {
    this.location.back();
  }

}
