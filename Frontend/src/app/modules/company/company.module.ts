import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserModule } from '@angular/platform-browser';
import { CompanyRoutingModule } from './company-routing.module';
import { CompanyViewComponent } from './comapny-view/comapny-view.component';
import { ComapnyFormComponent } from './comapny-form/comapny-form.component';
import { GridModule, EditService, ToolbarService } from '@syncfusion/ej2-ng-grids';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    GridModule,
    CompanyRoutingModule,
    GridModule
  ],
  declarations: [CompanyViewComponent, ComapnyFormComponent],
  exports: [CompanyViewComponent, ComapnyFormComponent],
  providers: [ToolbarService, EditService]
})

export class CompanyModule { }
