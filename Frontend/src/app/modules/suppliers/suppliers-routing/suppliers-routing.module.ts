import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersGridComponent } from './../suppliers-grid/suppliers-grid.component';
import { SuppliersComponent } from '../suppliers/suppliers.component';
import { SupplierComponent } from '../supplier/supplier.component';

const CustomerRoutes: Routes = [
  { path: 'suppliers',
    component: SuppliersGridComponent
  },
  { path: 'update/supplier/:id',
   component: SuppliersComponent
  },
  {
    path: 'add/supplier',
    component: SuppliersComponent
  },
  {
    path: 'detail/supplier',
    component: SupplierComponent
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
export class SuppliersRoutingModule { }
