import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './../users/users.component';
import { UserGridComponent } from './../user-grid/user-grid.component';


const UserRoutes: Routes = [
  { path: 'employees',
    component: UserGridComponent
  },
  { path: 'update/employee/:id',
   component: UsersComponent
  },
  {
    path: 'add/employee',
    component: UsersComponent
  }
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(UserRoutes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class UsersRoutingModule { }
