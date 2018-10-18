import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
// class, service and routings are imported here
import { UsersComponent } from './users.component';
import { UsersService } from './../users.service';
import { UsersRoutingModule } from './../users-routing/users-routing.module';
// syncfussion
import { ButtonModule, RadioButtonModule  } from '@syncfusion/ej2-ng-buttons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule, ResizeService, ExcelExportService  } from '@syncfusion/ej2-ng-grids';
import { NumericTextBoxComponent } from '@syncfusion/ej2-ng-inputs';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
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
        ToolbarService, FreezeService, SelectionService, CommandModel } from '@syncfusion/ej2-ng-grids';


@NgModule({
  imports: [
    CommonModule,
    UsersRoutingModule,
    // http client`
    HttpClientModule,
    // form mudules
    FormsModule,
    ReactiveFormsModule,
    // syncfussion modules
    ButtonModule,
    RadioButtonModule,
    DatePickerModule,
    GridModule
    // class, service & routings of the user module
  ],
  declarations: [
    UsersComponent,
    UserGridComponent
  ],
  providers: [UsersService,
    // data tPageService,
    SortService,
    FilterService,
    GroupService,
    EditService,
    ExcelExportService,
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
