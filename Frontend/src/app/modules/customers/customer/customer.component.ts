import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Customer } from './../customer';
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

  constructor(
    private customerService: CustomerService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    this.customersForm();
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
        Full_Name: [(customer.Full_Name) ? customer.Full_Name : '', Validators.required],
        Account_ID: [(customer.Account_ID) ? customer.Account_ID : '', Validators.required],
        Email: [(customer.Email) ? customer.Email : '', Validators.required],
        Phone_No: [(customer.Phone_No) ? customer.Phone_No : '', Validators.required],
        Country: [(customer.Country) ? customer.Country : '', Validators.required],
        City: [(customer.City) ? customer.City : '', Validators.required],
        Subcity: [(customer.Subcity) ? customer.Subcity : '', Validators.required],
        House_No: [(customer.House_No) ? customer.House_No : '', Validators.required],
        Postal_code: [(customer.Postal_code) ? customer.Postal_code : '', Validators.required],
        Date_Added: [(customer.Date_Added) ? customer.Date_Added : '', Validators.required],
        Date_Updated: [(customer.Date_Updated) ? customer.Date_Updated : '', Validators.required]
      });
  }
  // customer model
  customerModel(): any {
    const formModel = this.customerForm.value;
    const customerData = {
      id: this.id ? this.id : 0,
      Full_Name: formModel.Full_Name ? formModel.Full_Name : '',
      Account_ID: formModel.Account_ID ? formModel.Account_ID : '',
      Email: formModel.Email ? formModel.Email : '',
      Phone_No : formModel.Phone_No ? formModel.Phone_No : '',
      Country : formModel.Country ? formModel.Country : '',
      City : formModel.City ? formModel.City : '',
      SubCity : formModel.SubCity ? formModel.SubCity : '',
      House_No : formModel.House_No ? formModel.House_No : '',
      Postal_Code : formModel.Postal_code ? formModel.Postal_code : '',
      Date_Added : formModel.Date_Added ? formModel.Date_Added : '',
      Date_Updated : formModel.Date_Updated ? formModel.Date_Updated : ''
    };
    return customerData;
  }
// this function is called when submit button is clicked
  onSubmit() {

    const data = this.customerForm.value;
    if (this.customerForm.invalid) {
      return; // Validation failed, exit from method.
    }
    // Form is valid, now perform create or update
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

// this function is called when cancel button is clicked
  onCancel() {
    this.location.back();
  }
}
