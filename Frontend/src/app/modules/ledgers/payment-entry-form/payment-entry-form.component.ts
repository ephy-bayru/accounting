import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { LedgerService } from '../ledger.service';
import { Query, DataManager, WebApiAdaptor, ReturnOption } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-payment-entry-form',
  templateUrl: './payment-entry-form.component.html',
  styleUrls: ['./payment-entry-form.component.css']
})
export class PaymentEntryFormComponent implements OnInit {

  public paymentForm: FormGroup;
  public accountQuery: any;
  public accountFields: { text: string; value: string; };
  public accountList: Object[];

  constructor(private formbuilder: FormBuilder,
    private ledgerService: LedgerService) {
    this.createForm();
  }

  ngOnInit() {
    this.accountQuery = new Query().select(['Name', 'AccountId']);
    this.accountFields = { text: 'Name', value: 'AccountId' };
    const dm: DataManager = new DataManager(
      { url: 'http://localhost:53267/api/accounts', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    dm.ready.then((e: ReturnOption) => this.accountList = <Object[]>e.result).catch((e) => true);
  }


  createForm(): void {
    this.paymentForm = this.formbuilder.group({
      createdOn: ['', Validators.required],
      currencyId: ['', Validators.required],
      documentDate: ['', Validators.required],
      reference: ['', Validators.required],
      postingType: ['', Validators.required],
      postingId: ['', Validators.required],
      posterId: ['', Validators.required],
      posts: this.formbuilder.array([
        this.postEntry()
      ])
    });
  }

  postEntry(): FormGroup {
    return this.formbuilder.group({
      accountCode: ['', Validators.required],
      accountName: ['', Validators.required],
      amount: ['', Validators.required],
      memo: ['', Validators.required]
    });
  }


  get posts(): FormArray {
    return this.paymentForm.get('posts') as FormArray;
  }

  get createdOn(): FormControl {
    return this.paymentForm.get('createdOn') as FormControl;
  }

  get currencyId(): FormControl {
    return this.paymentForm.get('currencyId') as FormControl;
  }
  get docymentDate(): FormControl {
    return this.paymentForm.get('docymentDate') as FormControl;
  }
  get reference(): FormControl {
    return this.paymentForm.get('reference') as FormControl;
  }

  get postingType(): FormControl {
    return this.paymentForm.get('postingType') as FormControl;
  }

  get postingId(): FormControl {
    return this.paymentForm.get('postingId') as FormControl;
  }

  get posterId(): FormControl {
    return this.paymentForm.get('posterId') as FormControl;
  }


  addEntry(): void {
    this.posts.push(this.postEntry());
  }

}
