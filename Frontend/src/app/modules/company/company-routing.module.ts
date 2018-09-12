import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ComapnyFormComponent } from './comapny-form/comapny-form.component';
import { CompanyViewComponent } from './comapny-view/comapny-view.component';

const routes: Routes = [
  { path: 'organizations', component: CompanyViewComponent }, // organization view route
  { path: 'add/organization', component: ComapnyFormComponent }, // when creating a new organization data
  { path: 'update/organization/:organizationId', component: ComapnyFormComponent } // when updating organization data
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
