import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { Customer, CustomerAccount } from './../customer';
import { CustomerService } from './../customer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CustomerComponent implements OnInit {
  customerForm: FormGroup;
  customer: Customer;
  id: number;
  id_no: number;
  statusCode: any;
  show: false;
  delicon: any;
  imageonly: any;

// ─── CUSTOMERS CONSTRUCTOR ───────────────
  constructor(
    private customerService: CustomerService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    this.customersForm();
    this.delicon = 'e-icon e-delete';
    this.imageonly = 'imageonly';
  }

// ─── INITIALIZING THE CUSTOMER FORM AND CUSTOMERS ACCOUNT ─────────
  ngOnInit(): void {
    this.addAccount();
    this.id = + this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      this.customerService.getCustomer(this.id).subscribe((customer: Customer) => this.customersForm(customer));
      this.customersForm();
    }
  }

  // ─── CUSTOMERS FORM ────────────
  customersForm(customer: any = '') {
    this.customerForm = this
      .fb.group({
        FullName: [(customer.FullName) ? customer.FullName : '', Validators.required],
        Email: [(customer.Email) ? customer.Email : '', Validators.required],
        Phone_No: [(customer.Phone_No) ? customer.Phone_No : '', Validators.required],
        Country: [(customer.Country) ? customer.Country : '', Validators.required],
        City: [(customer.City) ? customer.City : '', Validators.required],
        Subcity: [(customer.Subcity) ? customer.Subcity : '', Validators.required],
        HouseNo: [(customer.HouseNo) ? customer.HouseNo : '', Validators.required],
        Postalcode: [(customer.PostalCode) ? customer.PostalCode : '', Validators.required],
        BankAccounts: this.fb.array([]),
      });
  }


  // ─── THIS FUNCTION IS CALLED WHEN SUBMIT BUTTON IS CLICKED ───────────
  onSubmit() {

    const data = this.prepareFormData(this.customerForm);
    if (this.id) {
      this
        .customerService
        .updateCustomer(data, this.id)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        }, errorCode => this.statusCode = errorCode);
    } else {
      this
        .customerService
        .addCustomer(data)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        }, errorCode => this.statusCode = errorCode);
    }
  }
  get BankAccounts(): FormArray {
    return this.customerForm.get('BankAccounts') as FormArray;
  }

  // ─── THIS FUNCTION IS CALLED WHEN CANCEL BUTTON IS CLICKED ────────────
  onCancel() {
    this.location.back();
  }
// ─── CUSTOMER MODEL ──────────────────────
  prepareFormData(form: FormGroup): Customer {
    const data = form.value;
    const customerData: Customer = new Customer();

    customerData.FullName = data.FullName;
    customerData.City = data.City;
    customerData.Country = data.Country;
    customerData.SubCity = data.SubCity;
    customerData.Email = data.Email;
    customerData.Phone_No = data.Phone_No;
    customerData.PostalCode = data.Postal_code;

    this.BankAccounts.controls.forEach(element => {
      const account: CustomerAccount = new CustomerAccount();
      const accountData = element.value;
      account.AccountNumber = accountData.AccountNumber;
      account.BankName = accountData.BankName;

      customerData.BankAccounts.push(account);
    });
    return customerData;
  }

// ─── THIS METHOD IS CALLED WHEN THE USER WANTS TO ADD A CUSTOMER ACCOUNT ──────
  addAccount() {
    this.BankAccounts.push(this.fb.group({
      BankName: ['', [Validators.required]],
      AccountNumber: ['', [Validators.required]]
    }));
  }
  removeAccount(i) {
    this.BankAccounts.removeAt(i);
  }

}
