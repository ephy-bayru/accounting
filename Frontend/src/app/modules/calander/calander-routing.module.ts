import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalanderViewComponent } from './calander-view/calander-view.component';
import { CalanderFormComponent } from './calander-form/calander-form.component';

const routes: Routes = [
  {path: 'calanders' , component: CalanderViewComponent},
  {path: 'calanders/new' , component: CalanderFormComponent},
  {path: 'calanders/update' , component: CalanderFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalanderRoutingModule { }
