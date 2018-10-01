import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AccountsComponent } from '../accounts/accounts.component';

const routes: Routes = [
  { path: 'accounts', component: AccountsComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class AccountsRoutingModule { }
