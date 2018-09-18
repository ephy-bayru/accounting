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
  public dateValue: Date = new Date('04/09/2018');
  public disable: false;
  public gender: 'Select Gender';
  title = 'User';
  userForm: FormGroup;
  user: Users;
  allUsers: Users;
  id: number;
  id_no: number;
  statusCode: any;
  requestProcessing = false;
  userUpdate = null;
  processValidation = false;
    public pageSettings: PageSettingsModel;
    // defined the array of data
    public data: { [key: string]: Object }[] = [
      { Class: 'male', Type: 'Male', Id: '1' },
      { Class: 'female', Type: 'Female ', Id: '2' },
    ];
  // map the icon column to iconCSS field.

  constructor(
    private usersService: UsersService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.usersForm();
    }
  ngOnInit(): void {
    this.id = + this.activatedRoute.snapshot.paramMap.get('id');
    console.log('user id' + this.id);
       this.usersService.getUser(this.id)
           .subscribe((user: Users) => this.usersForm(user));
           // data table
    this.getAllUsers();
    this.pageSettings = { pageSize: 1000 };
  }
  // this function is called
  usersForm(User: any = '') {
    this.id_no = User.id_no;
    console.log(User);
    this.userForm = this.fb.group({
      First_Name: User.First_Name ? [User.First_Name, Validators.required] :
        ['', Validators.required],
      Last_Name: User.Last_Name ? [User.Last_Name, Validators.required] :
        ['', Validators.required],
      Email: User.Email ? [User.Email, Validators.compose] :
        ['', Validators.required, Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')],
      Phone_No: User.Phone_No ? [User.Phone_No, Validators.required] :
        ['', Validators.required,  Validators.min(1000000000), Validators.max(9999999999)],
      Account_Id: User.Account_Id ? [User.Account_Id, Validators.required] :
        ['', Validators.required],
      Password: User.Password ? [User.Password, Validators.minLength(6)] :
        ['', Validators.required],
      Confirm_Password: User.Confirm_Password ? [User.Confirm_Password, Validators.required] :
      ['', Validators.required],
      Gender: User.Gender ? [User.Gender, Validators.required] :
        ['', Validators.required],
      Birth_Date: User.Birth_Date ? [User.Birth_Date, Validators.required] :
        ['', Validators.required]
    });
  }
  // user model
  userModel(): any {
    const formModel = this.userForm.value;
    console.log(formModel);
    const userData = {
      id: this.id ? this.id : 0,
      First_Name: formModel.First_Name ? formModel.First_Name : '',
      Last_Name: formModel.Last_Name ? formModel.Last_Name : '',
      Email: formModel.Email ? formModel.Email : '',
      Password: formModel.Password ? formModel.Password : '',
      Confirm_Password: formModel.Confirm_Password ? formModel.Confirm_Password : '',
      Gender: formModel.Gender ? formModel.Gender : '',
      Birth_Date: formModel.Birth_Date ? formModel.Birth_Date : ''
    };
    return userData;
  }
  // gell all users from database
  getAllUsers() {
    this.usersService.getUsers()
        .subscribe(
          data => this.allUsers = data,
          error => this.statusCode = error
        );
  }
  // this function called when the submit button is clicked
  onSubmit() {
    this.processValidation = true;
    if (this.userForm.invalid) {
      return; // Validation failed, exit from method.
    }
    // Form is valid, now perform create or update
    this.user = this.userModel();
    if (!this.userUpdate) {
      this.usersService.addUser(this.user)
          .subscribe(success => {
            this.statusCode = success;
            this.getAllUsers();
            this.router.navigate(['users']);
    },
    errorCode => this.statusCode = errorCode);
  } else {
    this.usersService.updateUser(this.user, this.id)
        .subscribe(success => {
          this.statusCode = success;
          this.getAllUsers();
          this.back();
        },
        errorCode => this.statusCode = errorCode);
    }
  }
  public isFieldValid(field: string) {
    return !this.userForm.get(field).valid && (this.userForm.get(field).dirty || this.userForm.get(field).touched);
  }
  // cancel button function
  onCancel() {
   // this.route
  }
// delete function
  onDelete(id: number) {
    this.preProcessConfigurations();
    this.usersService.deleteUser(id)
        .subscribe(successCode => {
        //  this.statusCode = successCode;
          this.statusCode = 204;
          this.back();
        },
      errorCode => this.statusCode = errorCode);
  }
  // preprocess configuration
  preProcessConfigurations() {
    this.statusCode = null;
    this.requestProcessing = true;
  }
  // this function will reset the form
  back() {
    this.userUpdate = null;
    this.userForm.reset();
    this.processValidation = false;
  }
  // data table sort
  // const sortColor = (xColor: string, yColor: string) => {
  //     return getHSL(xColor).val - getHSL(yColor).val;
  // }
  // users component html style controller functions

public focusIn(target: HTMLElement): void {
  target.parentElement.classList.add('e-input-focus');
}

public focusOut(target: HTMLElement): void {
    target.parentElement.classList.remove('e-input-focus');
}

public onMouseDown(target: HTMLElement): void {
    target.classList.add('e-input-btn-ripple');
}

public onMouseUp(target: HTMLElement): void {
    const ele: HTMLElement = target;
    setTimeout(
            () => {ele.classList.remove('e-input-btn-ripple'); },
            500);
}

}
