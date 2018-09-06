import { Component, OnInit, ViewEncapsulation} from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Users } from './../users';
import { UsersService } from './../users.service';
import { Router, ActivatedRoute } from '@angular/router';
import {PageSettingsModel } from '@syncfusion/ej2-ng-grids';

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
  // data table
  // public data: Object[];
  public pageSettings: PageSettingsModel;

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
      Last_Name: User.First_Name ? [User.First_Name, Validators.required] :
        ['', Validators.required],
      Email: User.Email ? [User.Email, Validators.compose] :
        ['', Validators.required, Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')],
      Account_Id: User.Account_Id ? [User.Account_Id, Validators.required] :
        ['', Validators.required],
      Password: User.Password ? [User.Password, Validators.minLength(6)] :
        ['', Validators.required],
      Confirm_Password: User.Confirm_Password ? [User.Confirm_Password, Validators.required] :
      ['', Validators.required],
      Gender: User.Gender ? [User.Gender, Validators.required] :
        ['', Validators.required],
      Birth_Date: User.Birth_Date ? [User.Birth_Date, Validators.required] :
        ['', Validators.required],
      Date_Created: User.Date_Created ? [User.Date_Created, Validators.required] :
      ['', Validators.required],
      Date_Updated: User.Date_Updated ? [User.Date_Updated, Validators.required] :
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
      Birth_Date: formModel.Birth_Date ? formModel.Birth_Date : '',
      Date_Created: formModel.Date_Created ? formModel.Date_Created : '',
      Date_Updated: formModel.Date_Updated ? formModel.Date_Updated : ''
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
            this.back();
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
