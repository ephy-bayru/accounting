import { Component, OnInit, ViewEncapsulation, ViewChild} from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Users } from './../users';
import { UsersService } from './../users.service';
import { Router, ActivatedRoute } from '@angular/router';
import {PageSettingsModel } from '@syncfusion/ej2-ng-grids';
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
  public gender: 'Select Gender';
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
    private activatedRoute: ActivatedRoute
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
    this
      .usersService
      .getUser(this.id)
      .subscribe((user: Users) => this.usersForm(user));

      this.usersForm();
  }

  // this function is called
  usersForm(User: any = '') {
    this.userForm = this
      .fb
      .group({
        First_Name: User.First_Name
          ? [User.First_Name, Validators.required]
          : [
            '', Validators.required
          ],
        Last_Name: User.Last_Name
          ? [User.Last_Name, Validators.required]
          : [
            '', Validators.required
          ],
        Email: User.Email
          ? [User.Email, Validators.compose]
          : [
            '', Validators.required
          ],
        Phone_No: User.Phone_No
          ? [User.Phone_No, Validators.required]
          : [
            '', Validators.required
          ],
        Account_Id: User.Account_Id
          ? [User.Account_Id, Validators.required]
          : [
            '', Validators.required
          ],
        Password: User.Password
          ? [
            User.Password, Validators.minLength(6)
          ]
          : [
            '', Validators.required
          ],
        Confirm_Password: User.Confirm_Password
          ? [User.Confirm_Password, Validators.minLength(6)]
          : [
            '', Validators.required
          ],
        Gender: User.Gender
          ? [User.Gender, Validators.required]
          : [
            '', Validators.required
          ],
        Birth_Date: User.Birth_Date
          ? [new Date(), Validators.required]
          : [new Date(), Validators.required]
      });
  }
  // user model
  userModel(): any {
    const formModel = this.userForm.value;
    console.log(formModel);
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
  console.log('hi');
  const data = this.userForm.value;
//  if (this.userForm.invalid) {
  //  return; // Validation failed, exit from method.
  // }
  // Form is valid, now perform create or update
  if (this.userUpdate) {
    this
      .usersService
      .updateUser(data, this.id)
      .subscribe(success => {
        this.statusCode = success;
        this.router.navigate(['user-grid']);
      }, errorCode => this.statusCode = errorCode);
  } else {
    this
    .usersService
    .addUser(data)
    .subscribe(success => {
      this.statusCode = success;
      this
        .router
        .navigate(['users-grid']);
    }, errorCode => this.statusCode = errorCode);
  }
}
public isFieldValid(field: string) {
  return !this
    .userForm
    .get(field)
    .valid && (this.userForm.get(field).dirty || this.userForm.get(field).touched);
}
// cancel button function
onCancel() {
  this.userForm.reset();
  this.router.navigate(['user-grid']);
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
