import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CustomerGridComponent } from './../customer-grid/customer-grid.component';
import { CustomerComponent } from '../customer/customer.component';

const CustomerRoutes: Routes = [
  { path: 'customers',
    component: CustomerGridComponent
  },
  { path: 'update/customer/:id',
   component: CustomerComponent
  },
  {
    path: 'add/customer',
    component: CustomerComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CustomerRoutes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class CustomerRoutingModule { }
