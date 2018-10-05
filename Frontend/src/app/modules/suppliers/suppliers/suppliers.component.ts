import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormBuilder, FormGroup, FormControl} from '@angular/forms';
import { SuppliersService } from './../suppliers.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Suppliers } from './../suppliers';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css'],
  encapsulation: ViewEncapsulation.None

})
export class SuppliersComponent implements OnInit {
  public readonly: true;
  public disable: false;
  suppplierForm: FormGroup;
  supplier: Suppliers;
  id: number;
  id_no: number;
  statusCode: any;
  userUpdate = null;

  constructor(
    private suppliersService: SuppliersService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    this.suppliersForm();
  }

  ngOnInit(): void {
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
    this.suppplierForm = this
      .fb
      .group({
        Full_Name: ['', [Validators.required,
          Validators.minLength(2),
          Validators.maxLength(64)]],
        Email: ['', [Validators.required,
          Validators.email,
          Validators.maxLength(256)]],
        Phone_No: ['', [Validators.required,
          Validators.minLength(9),
          Validators.maxLength(32)]],
        Account_Number: ['', [Validators.required,
          Validators.minLength(9)]],
        Account_id: ['', Validators.required],
        Country:  ['', Validators.required],
        City:  ['', Validators.required],
        SubCity:  ['', Validators.required],
        House_No:  ['', Validators.required],
        Postal_Code:  ['', Validators.required]
      });
  }

  supplierModel(): any {
    const formModel = this.suppplierForm.value;

    const supplierData = {
      id: this.id
        ? this.id
        : 0,
      Full_Name: formModel.Full_Name
        ? formModel.Full_Name
        : '',
      Email: formModel.Email
        ? formModel.Email
        : '',
      Phone_No: formModel.Phone_No
        ? formModel.Phone_No
        : '',
      Account_Number: formModel.Account_Number
        ? formModel.Account_Number
        : '',
      Account_id: formModel.Account_id
        ? formModel.Account_id
        : '',
      Country: formModel.Country
        ? formModel.Country
        : '',
      City: formModel.City
        ? formModel.City
        : '',
      SubCity: formModel.SubCity
        ? formModel.SubCity
        : '',
      House_No: formModel.House_No
        ? formModel.House_No
        : '',
      Postal_Code: formModel.Postal_Code
        ? formModel.Postal_Code
        : '',
    };
    return supplierData;
  }

  onSubmit() {
    const supplier = this.suppplierForm.value;
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

}
