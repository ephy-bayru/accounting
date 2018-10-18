/*
 * @CreateTime: Sep 6, 2018 4:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2018 12:40 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute} from '@angular/router';
import { Organization, CompanyService } from 'src/app/modules/company/company.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Location } from '@angular/common';

@Component({
  selector: 'app-comapny-form',
  templateUrl: './comapny-form.component.html',
  styleUrls: ['./comapny-form.component.css']
})
export class ComapnyFormComponent implements OnInit {

  private organizationId: number;
  organizationForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
              private location: Location,
              private organizationService: CompanyService,
              private activatedRoute: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.organizationId = + this.activatedRoute.snapshot.paramMap.get('organizationId');
    if (this.organizationId) {
      this.organizationService.getOrganizationById(this.organizationId).subscribe(
        (success: Organization) => this.populateForm(success),
        (error: HttpErrorResponse) => this.handelError(error)
      );
    }

    this.initalizeForm();
  }


  initalizeForm() {
    this.organizationForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Location: ['', Validators.required],
      Tin:  ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]]
    });

  }

  cancel() {
    this.location.back();
  }
  populateForm(organization: Organization) {
    console.log(organization.name);
    this.organizationForm = this.formBuilder.group({
      Name: [organization.name, Validators.required],
      Location: [organization.location, Validators.required],
      Tin: [organization.tin, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]]
    });
  }
  public focusIn(target: HTMLElement): void {
    target.parentElement.classList.add('e-input-focus');
  }

  public focusOut(target: HTMLElement): void {
    target.parentElement.classList.remove('e-input-focus');
  }

  public onMouseDown(target: HTMLElement): void {
    target.classList.add('e-input-btn-ripple');
  }

  public onMouseUp(target: HTMLElement): void {
    const ele: HTMLElement = target;
    setTimeout(
      () => { ele.classList.remove('e-input-btn-ripple'); },
      500);
  }

  prepareData(): Organization {
    const form = this.organizationForm.value;
    return {
      name: form.Name,
      location: form.Location,
      tin: form.Tin
    };
  }
  handelSuccess(response: Organization | Boolean) {
    this.location.back();
  }

  handelError(error: HttpErrorResponse) {

  }
  onSubmit() {
    const data = this.prepareData();
    if (this.organizationId) {
      this.organizationService.updateOrganization(this.organizationId, data).subscribe(
        success => this.handelSuccess(success),
        error => this.handelError(error)
      );
    }
    this.organizationService.createOrganization(data).subscribe(
      success => this.handelSuccess(success),
      error => this.handelError(error)
    );
  }

}
