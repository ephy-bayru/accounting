import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ComapnyFormComponent } from './comapny-form/comapny-form.component';
import { CompanyViewComponent } from './comapny-view/comapny-view.component';

const routes: Routes = [
  {path: 'organizations' , component : CompanyViewComponent },
  {path: 'add/organization', component : ComapnyFormComponent},
  {path: 'update/organization/:organizationId', component : ComapnyFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
