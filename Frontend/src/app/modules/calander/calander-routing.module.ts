import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalanderViewComponent } from './calander-view/calander-view.component';
import { CalanderFormComponent } from './calander-form/calander-form.component';

const routes: Routes = [
  {path: 'calander' , component: CalanderViewComponent},
  {path: 'add/calander' , component: CalanderFormComponent},
  {path: 'update/calander' , component: CalanderViewComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalanderRoutingModule { }
