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
  public accountForm: FormGroup;
  public accountQuery: Query;
  public accountFields: Object;
  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder, private account: AccountsService) {
    this.createForm();
  }

  ngOnInit() {
    this.accountQuery = new Query().select(['code', 'id']);
    this.accountFields = { text: 'accountId', value: 'accountCode' };
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
          parent: '',
          accountName: '',
          active: [false]
        })])

    });
  }

  addPeriod() {
    this.accounts.push(this.formBuilder.group({
      accountCode: [[new Date(), new Date()], Validators.required],
      accountName: '',
      parent: '',
      active: [false]
    }));
  }

  get accounts(): FormArray {
    return this.accountForm.get('accounts') as FormArray;
  }

  onSubmit() {

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
