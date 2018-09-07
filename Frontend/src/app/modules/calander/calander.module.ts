import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CalanderRoutingModule } from './calander-routing.module';
import { CalanderFormComponent } from './calander-form/calander-form.component';
import { CalanderViewComponent } from './calander-view/calander-view.component';

@NgModule({
  imports: [
    CommonModule,
    CalanderRoutingModule
  ],
  declarations: [CalanderFormComponent, CalanderViewComponent]
})
export class CalanderModule { }
