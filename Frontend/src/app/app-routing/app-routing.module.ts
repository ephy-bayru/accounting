import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from '../modules/users/users/users.component';
import { CompanyViewComponent } from '../modules/company/comapny-view/comapny-view.component';
import { ComapnyFormComponent } from '../modules/company/comapny-form/comapny-form.component';
import { UserGridComponent } from '../modules/users/user-grid/user-grid.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'users/', component: UsersComponent},
  { path: 'users-grid', component: UserGridComponent},
  { path: 'organizations/', component: CompanyViewComponent},
  { path: 'new/organization/', component: ComapnyFormComponent}
];
@NgModule({
  imports: [
    CommonModule, RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule {

}
