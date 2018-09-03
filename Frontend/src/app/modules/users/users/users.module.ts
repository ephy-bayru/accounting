import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatCardModule} from '@angular/material/card';
import {MatExpansionModule} from '@angular/material/expansion';
// class, service and routings are imported here
import { UsersComponent } from './users.component';
import { UsersService } from './../users.service';
// syncfussion
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';

@NgModule({
  imports: [
    CommonModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCardModule,
    MatExpansionModule,
    // syncfussion modules
    ButtonModule
    // class, service & routings of the user module
  ],
  declarations: [UsersComponent],
  providers: [UsersService]
})
export class UsersModule { }
