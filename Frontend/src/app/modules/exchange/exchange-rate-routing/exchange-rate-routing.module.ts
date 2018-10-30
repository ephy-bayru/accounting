import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ExchangerateComponent } from './../exchange_rate/exchange_rate.component';
import { ExRateGridComponent } from './../exchange-rate-grid/exchange-rate-grid.component';


const xRateRoutes: Routes = [
  { path: 'exrate',
    component: ExRateGridComponent
  },
  { path: 'update/exrate/:id',
   component: ExchangerateComponent
  },
  {
    path: 'add/exrate',
    component: ExchangerateComponent
  }
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(xRateRoutes)
  ],
  declarations: []
})
export class ExRateRoutingModule { }
