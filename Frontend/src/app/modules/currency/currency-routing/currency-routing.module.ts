import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CurrencyComponent } from './../currency/currency.component';
import { CurrencyGridComponent } from './../currency-grid/currency-grid.component';


const CurrencyRoutes: Routes = [
  { path: 'currencies',
    component: CurrencyGridComponent
  },
  { path: 'update/currency/:id',
   component: CurrencyComponent
  },
  {
    path: 'add/currency',
    component: CurrencyComponent
  }
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CurrencyRoutes)
  ],
  declarations: []
})
export class CurrencyRoutingModule { }
