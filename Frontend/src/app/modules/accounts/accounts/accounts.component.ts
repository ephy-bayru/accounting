/*
 * @CreateTime: Nov 3, 2018 10:17 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 10:34 AM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
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
  public postingType: Object[];
  public glType: Object[];

  public accountTypes: Object = ['ASSET', 'LIABILITY', 'REVENUE', 'EXPENCE', 'INCOME'];
  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder,
    private account: AccountsService,
    private location: Location,
    private activatedRoute: ActivatedRoute) {
    this.createForm();
    this.postingType = ['CREDIT', 'DEBIT', 'BOTH'];
    this.glType = ['INCOME STATEMENT', 'BALANCE SHEET'];
  }

  ngOnInit() {
    this.accountId = this.activatedRoute.snapshot.paramMap.get('accountId');

    if (this.accountId != null) {
      this.account.getAccountById(this.accountId).subscribe(data => this.createForm(data));
    }
    this.accountQuery = new Query().select(['Name', 'AccountId']);
    this.accountFields = { text: 'Name', value: 'AccountId' };
    this.organizationQuery = new Query().select(['name', 'id']);
    this.organizationFields = { text: 'name', value: 'id' };

    const orgDm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/organizations', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(5)
    );
    orgDm.ready.then((e: ReturnOption) => this.organizationList = <Object[]>e.result).catch((e) => true);

    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);
  }

  get AccountId(): FormControl {
    return this.accountForm.get('AccountId') as FormControl;
  }

  get AccountType(): FormControl {
    return this.accountForm.get('AccountType') as FormControl;
  }

  get Name(): FormControl {
    return this.accountForm.get('Name') as FormControl;
  }

  get PostingType(): FormControl {
  return this.accountForm.get('PostingType') as FormControl;
  }

  get GlType(): FormControl {
    return this.accountForm.get('GlType') as FormControl;
  }

  get OrganizationId(): FormControl {
    return this.accountForm.get('OrganizationId') as FormControl;
  }


  createForm(data: any = '') {

    this.accountForm = this.formBuilder.group({
      AccountCode: [data.AccountCode],
      AccountId: [data.AccountId, Validators.required],
      AccountType: [data.AccountType, Validators.required],
      Name: [data.Name, Validators.required],
      Active: [(data.Active === 1) ? true : false],
      OpeningBalance: 0,
      OrganizationId: [data.OrganizationId, Validators.required],
      PostingType: [(data.Type) ? data.Type : 'Both', Validators.required],
      IsReconcilation: [(data.IsReconcilation === 0) ? false : true, Validators.required],
      IsPosting: [(data.DirectPosting === 0) ? false : true, Validators.required],
      GlType: [(data.GlType) ? data.GlType : null, Validators.required]
    });
  }


  onSubmit() {
    if (!this.accountId) {
      this.account.createAccount(this.accountForm.value).subscribe((success) => {
        alert('Account Created Successfully');
        this.location.back();
      },
        (error: HttpErrorResponse) => {
          alert(error.message);
        });
    } else {
      this.account.updateAccount(this.accountId, this.accountForm.value).subscribe((success: Object) => {
        this.location.back();
        alert('Account Updated Successfully');
      },
        (error: HttpErrorResponse) => {
          alert(error.message);
        });
    }
  }


  cancel() {
    this.location.back();
  }

}
