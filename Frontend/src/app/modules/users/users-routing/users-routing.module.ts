import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './../users/users.component';
import { UserGridComponent } from './../user-grid/user-grid.component';


const UserRoutes: Routes = [
  { path: 'users',
    component: UsersComponent
  },
  { path: 'users/id',
   component: UsersComponent
  },
  {
    path: 'users-grid',
    component: UserGridComponent
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
