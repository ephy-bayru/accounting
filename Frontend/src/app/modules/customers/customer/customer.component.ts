import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup, FormControl, FormArray } from '@angular/forms';
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

  ngOnInit(): void {
    this.id = + this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      this.customerService.getCustomer(this.id).subscribe((customer: Customer) => this.customersForm(customer));
      this.customersForm();
    }
  }
  // customer form
  customersForm(customer: any = '') {
    this.customerForm = this
      .fb.group({
        FullName: [(customer.Full_Name) ? customer.Full_Name : '', Validators.required],
        Email: [(customer.Email) ? customer.Email : '', Validators.required],
        Phone_No: [(customer.Phone_No) ? customer.Phone_No : '', Validators.required],
        Country: [(customer.Country) ? customer.Country : '', Validators.required],
        City: [(customer.City) ? customer.City : '', Validators.required],
        Subcity: [(customer.Subcity) ? customer.Subcity : '', Validators.required],
        HouseNo: [(customer.House_No) ? customer.House_No : '', Validators.required],
        Postalcode: [(customer.Postal_code) ? customer.Postal_code : '', Validators.required],
        BankAccounts: this.fb.array ([
        ]),

      });
  }
  // customer model

// this function is called when submit button is clicked
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
// this function is called when cancel button is clicked
  onCancel() {
    this.location.back();
  }

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

      this.BankAccounts.controls.forEach(element  => {
       const account: CustomerAccount = new CustomerAccount();
       const accountData = element.value;
        account.AccountNumber = accountData.AccountNumber;
        account.BankName = accountData.BankName;

        customerData.BankAccounts.push(account);
      });
return customerData;
  }

addAccount() {
  this.BankAccounts.push( this.fb.group ({
    BankName: ['', [Validators.required]],
    AccountNumber: ['', [Validators.required]]
}));
}
removeAccount(i) {
  this.BankAccounts.removeAt(i);
}

}
