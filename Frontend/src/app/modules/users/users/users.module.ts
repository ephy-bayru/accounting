import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatCardModule} from '@angular/material/card';
import {MatExpansionModule} from '@angular/material/expansion';
// class, service and routings are imported here
import { UsersComponent } from './users.component';
import { UsersService } from './../users.service';
// syncfussion
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePickerModule } from '@syncfusion/ej2-ng-calendars';
import { GridModule, ResizeService  } from '@syncfusion/ej2-ng-grids';
import { NumericTextBoxComponent } from '@syncfusion/ej2-ng-inputs';
import { UserGridComponent } from './../user-grid/user-grid.component';
import { PageService,
         SortService,
        FilterService,
        GroupService,
        EditService,
        ColumnChooserService,
        ColumnMenuService,
        DetailRowService,
        SearchService,
        PdfExportService,
        ReorderService,
        CommandColumnService,
        ToolbarService, } from '@syncfusion/ej2-ng-grids';


@NgModule({
  imports: [
    CommonModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCardModule,
    MatExpansionModule,
    // http client`
    HttpClientModule,
    // form mudules
    FormsModule,
    ReactiveFormsModule,
    // syncfussion modules
    ButtonModule,
    DatePickerModule,
    GridModule
    // class, service & routings of the user module
  ],
  declarations: [
    UsersComponent,
    UserGridComponent,
    NumericTextBoxComponent
  ],
  providers: [UsersService,
    // data table services
              PageService,
              SortService,
              FilterService,
              GroupService,
              EditService,
              ColumnChooserService,
              ColumnMenuService,
              DetailRowService,
              SearchService,
              PdfExportService,
              ReorderService,
              CommandColumnService,
              ToolbarService,
              ResizeService

            ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class UsersModule { }
