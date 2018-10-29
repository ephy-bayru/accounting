import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LedgerComponent } from '../ledger/ledger.component';
import { Routes, RouterModule } from '@angular/router';
import { LedgerViewComponent } from '../ledger-view/ledger-view.component';



const routes: Routes = [
  { path: 'ledgers', component: LedgerViewComponent }, // organization view route
  { path: 'ledgers/entry', component: LedgerComponent } // when creating a new organization data
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class LedgerRoutingModule { }
