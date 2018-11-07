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
  public accountList: Object[];  // Holds Accounts for the drop down
  public organizationList: Object[]; // holds organization for the drop down
  public accountForm: FormGroup; // tmain formgroup
  public accountQuery: Query;  // used  to filter the fields we want to use for account
  public isUpdate: Boolean = false; // used as a flag to determine current operation
  public accountFields: Object; // holds the serlected fields to display on the drop down
  public organizationQuery: Query; // used  to filter the fields we want to use for organization
  public organizationFields: Object; // holds the selected fields to display on the drop down
  public calendarQuery: Query; // used  to filter the fields we want to use for calander period
  public calendarFields: Object; // holds the selected fields to display on the drop down
  public postingType: Object[]; // holdes values for available general ledger posting types
  public glType: Object[]; // holdes values for available general ledger  types

  private accountId: string; // used to hold the account Id passed in the route

  public accountTypes: Object;
  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder,
    private account: AccountsService,
    private location: Location,
    private activatedRoute: ActivatedRoute) {
      // intialize the form
    this.createForm();
    this.accountTypes = ['ASSET', 'LIABILITY', 'REVENUE', 'EXPENCE', 'INCOME'];
    this.postingType = ['CREDIT', 'DEBIT', 'BOTH'];
    this.glType = ['INCOME STATEMENT', 'BALANCE SHEET'];
  }

  ngOnInit() {
    // get the accountId from route parameter if present
    this.accountId = this.activatedRoute.snapshot.paramMap.get('accountId');

    if (this.accountId != null) { // if account id is present get the related account value
      this.isUpdate = true;
        // initialize the form with the retrived account value
      this.account.getAccountById(this.accountId).subscribe(data => this.createForm(data));
    }
    this.accountQuery = new Query().select(['Name', 'AccountId']);
    this.accountFields = { text: 'Name', value: 'AccountId' };
    this.organizationQuery = new Query().select(['name', 'id']);
    this.organizationFields = { text: 'name', value: 'id' };

    // get organization list to fill the organization drop down from back end
    const orgDm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/organizations', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(5)
    );
    orgDm.ready.then((e: ReturnOption) => this.organizationList = <Object[]>e.result).catch((e) => true);

      // get account list to fill the Accounts drop down from back end
    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);
  }

  /* Creating value accessors for the reactive form
  for use inside the template
  */
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

  /* initializes the formgroup structure
  if called without a parameter the fields will have a default value
  else they will be be assigned value retrived from the function argument
  */
  createForm(data: any = '') {

    this.accountForm = this.formBuilder.group({
      AccountCode: [data.AccountCode],
      AccountId: [data.AccountId, Validators.required],
      AccountType: [data.AccountType, Validators.required],
      Name: [data.Name, Validators.required],
      Active: [(data.Active === 0) ? false : true],
      OpeningBalance: [(this.accountId) ? { value: 100, readonly: true } : 0],
      OrganizationId: [data.OrganizationId, Validators.required],
      PostingType: [(data.Type) ? data.Type : 'BOTH', Validators.required],
      IsReconcilation: [(data.IsReconcilation === 0) ? false : true, Validators.required],
      IsPosting: [(data.DirectPosting === 0) ? false : true, Validators.required],
      GlType: [(data.GlType) ? data.GlType : null, Validators.required]
    });
  }

  /*
  called on the form submit event to handel
  the request with appropriate action
  i.e. add or update
  */
  onSubmit() {
    // check if  current operation is update
    if (!this.isUpdate) {
      this.account.createAccount(this.accountForm.value).subscribe((success) => {
        alert('Account Created Successfully');
        this.location.back(); // on success return back to where the user previously was
      },
        (error: HttpErrorResponse) => {
          alert(error.message); // on error show the error message
        });
    } else {
      this.account.updateAccount(this.accountId, this.accountForm.value).subscribe((success: Object) => {
        this.location.back();
        alert('Account Updated Successfully');  // on success return back to where the user previously was
      },
        (error: HttpErrorResponse) => {
          alert(error.message); // on error show the error message
        });
    }
  }

  /*
  used to handel the event when user click the cancel button
  it will return the user to wherever the user came from previously
  */
  cancel() {
    this.location.back();
  }

}
