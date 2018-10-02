import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AccountsComponent } from '../accounts/accounts.component';
import { AccountsViewComponent } from '../accounts-view/accounts-view.component';

const routes: Routes = [
  { path: 'accounts', component: AccountsViewComponent },
  { path: 'accounts/new', component: AccountsComponent }
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
