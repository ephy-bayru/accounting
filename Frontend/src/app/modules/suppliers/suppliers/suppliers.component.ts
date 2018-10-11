import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup, FormControl, FormArray } from '@angular/forms';
import { SuppliersService } from './../suppliers.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Suppliers, SupplierAccount } from './../suppliers';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css'],
  encapsulation: ViewEncapsulation.None

})
export class SuppliersComponent implements OnInit {
  public readonly: true;
  public disable: false;
  supplierForm: FormGroup;
  supplier: Suppliers;
  id: number;
  id_no: number;
  statusCode: any;
  userUpdate = null;
  show: false;
  update: false;

  constructor(
    private suppliersService: SuppliersService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    this.suppliersForm();
  }

  ngOnInit(): void {
    this.activatedRoute.params
      .subscribe(
        (params: Params) => {
          this.id = +params['id'];
          this.suppliersForm();
          this.addAccount();
        }
      );
    this.id = +this
      .activatedRoute
      .snapshot
      .paramMap
      .get('id');
    if (this.id) {
      this
        .suppliersService
        .getSupplier(this.id)
        .subscribe((supplier: Suppliers) => this.suppliersForm(supplier));
      this.suppliersForm();
    }
  }
  suppliersForm(Supplier: any = '') {
    this.supplierForm = this
      .fb
      .group({
        FullName: ['', [Validators.required,
        Validators.minLength(2),
        Validators.maxLength(64)]],
        Email: ['', [Validators.required,
        Validators.email,
        Validators.maxLength(256)]],
        Phone_No: ['', [Validators.required,
        Validators.minLength(9),
        Validators.maxLength(32)]],
        Country: ['', Validators.required],
        City: ['', Validators.required],
        SubCity: ['', Validators.required],
        HouseNo: ['', Validators.required],
        PostalCode: ['', Validators.required],
        BankAccounts: this.fb.array([
        ]),
      });
  }
phoneNumber(): FormControl {
  return this.supplierForm.get('Phone_No') as FormControl;
}

  prepareFormData(form: FormGroup): Suppliers {
    const data = form.value;
    const supplierData: Suppliers = new Suppliers();
    supplierData.FullName = data.FullName;
    supplierData.Email = data.Email;
    supplierData.Phone_No = data.Phone_No;
    supplierData.Country = data.Country;
    supplierData.City = data.City;
    supplierData.SubCity = data.SubCity;
    supplierData.HouseNo = data.House_No;
    supplierData.PostalCode = data.Postal_Code;

    this.BankAccounts.controls.forEach(element => {
      const account: SupplierAccount = new SupplierAccount();
      const accountData = element.value;
      account.AccountNumber = accountData.AccountNumber;
      account.BankName = accountData.BankName;

      supplierData.BankAccounts.push(account);
    });
    return supplierData;
  }


  onSubmit() {
    const supplier = this.prepareFormData(this.supplierForm);
    if (this.id) {
      this
        .suppliersService
        .updateSupplier(supplier, this.id)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        }, errorCode => this.statusCode = errorCode);
    } else {
      this
        .suppliersService
        .addSupplier(supplier)
        .subscribe(success => {
          this.statusCode = success;
          this.location.back();
        }, errorCode => this.statusCode = errorCode);
    }
  }
  // cancel button function
  onCancel() {
    this.location.back();
  }
  get BankAccounts(): FormArray {
    return this.supplierForm.get('BankAccounts') as FormArray;
  }
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
