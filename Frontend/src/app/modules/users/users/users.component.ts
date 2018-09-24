import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Users } from './../users';
import { UsersService } from './../users.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-ng-grids';
import { EmitType } from '@syncfusion/ej2-base';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UsersComponent implements OnInit {
  public readonly: true;
  public disable: false;
  public dateValue: Date = new Date();
  userForm: FormGroup;
  user: Users;
  id: number;
  id_no: number;
  statusCode: any;
  requestProcessing = false;
  userUpdate = null;
  processValidation = false;
  constructor(
    private usersService: UsersService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {
    this.usersForm();
  }

  ngOnInit(): void {
    this.id = +this
      .activatedRoute
      .snapshot
      .paramMap
      .get('id');
    // console.log('user id' + this.id);
    if (this.id) {
      this
        .usersService
        .getUser(this.id)
        .subscribe((user: Users) => this.usersForm(user));
      this.usersForm();
    }
  }

  // this function is called
  usersForm(User: any = '') {
    this.userForm = this
      .fb
      .group({
        First_Name: [(User.FirstName) ? User.FirstName : '', Validators.required ]
          ,
        Last_Name: [(User.LastName) ? User.LastName : '', Validators.required ]
          ,
        Email: [(User.Email) ? User.Email : '', Validators.required ]
          ,
        Phone_No: [(User.PhoneNo) ? User.PhoneNo : '', Validators.required ]
          ,
        Account_Id: [(User.AccountId) ? User.AccountId : '', Validators.required ]
          ,
        Password: ''
        ,
        Confirm_Password: '',
        Gender: [(User.Gender) ? User.Gender : '', Validators.required ],
        Birth_Date: [ (User.BirthDate) ? new Date(User.BirthDate) : User.BirthDate , Validators.required]
      });
  }
  // user model
  userModel(): any {
    const formModel = this.userForm.value;

    const userData = {
      id: this.id
        ? this.id
        : 0,
      First_Name: formModel.First_Name
        ? formModel.First_Name
        : '',
      Last_Name: formModel.Last_Name
        ? formModel.Last_Name
        : '',
      Email: formModel.Email
        ? formModel.Email
        : '',
      Password: formModel.Password
        ? formModel.Password
        : '',
      Confirm_Password: formModel.Confirm_Password
        ? formModel.Confirm_Password
        : '',
      Gender: formModel.Gender
        ? formModel.Gender
        : '',
      Birth_Date: formModel.Birth_Date
        ? formModel.Birth_Date
        : ''
    };
    return userData;
  }
  onSubmit() {

    const data = this.userForm.value;
    //  if (this.userForm.invalid) {
    //  return; // Validation failed, exit from method.
    // }
    // Form is valid, now perform create or update
    if (this.id) {
      this
        .usersService
        .updateUser(data, this.id)
        .subscribe(success => {
          this.statusCode = success;
          // this.router.navigate(['employees']);
          this.location.back();
        }, errorCode => this.statusCode = errorCode);
    } else {
      this
        .usersService
        .addUser(data)
        .subscribe(success => {
          this.statusCode = success;
        this.location.back();
        }, errorCode => this.statusCode = errorCode);
    }
  }
  public isFieldValid(field: string) {

  }
  // cancel button function
  onCancel() {
    this.location.back();
  }
  // delete function
  onDelete(id: number) {
    this
      .usersService
      .deleteUser(id)
      .subscribe(successCode => {
        //  this.statusCode = successCode;
        this.statusCode = 204;
      }, errorCode => this.statusCode = errorCode);
  }

}
