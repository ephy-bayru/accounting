import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { RangeEventArgs } from '@syncfusion/ej2-calendars';
import { CalanderPeriod, CalanderService } from '../calander.service';
import { forEach } from '@angular/router/src/utils/collection';
import { element } from 'protractor';

@Component({
  selector: 'app-calander-form',
  templateUrl: './calander-form.component.html',
  styleUrls: ['./calander-form.component.css']
})
export class CalanderFormComponent implements OnInit {
  calanderForm: FormGroup;

  public minDays: Number = 30;
  public maxDays: Number = 31;
  public format: String = 'yyyy-MM-dd'; // 2018-09-17
  public firstDay: Number = 1; // Monday
  public calanderList: CalanderPeriod[] = [];
  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder, private calanderPeriodAPI: CalanderService) {
    this.createForm();

  }

  ngOnInit() {
  }

  dateChanged(date: RangeEventArgs) {

    const start = new Date(date.startDate);
    const end = new Date(date.endDate);
    if (this.calanders.controls.length > 1) {

      for (let i = 0; i < this.calanders.controls.length; i++) {

        const startPeriod = this.calanders.controls[i].value[0] as Date;

        const endPeriod = this.calanders.controls[i].value[1] as Date;

        if (
          (start > startPeriod && start < endPeriod) ||
          (end < endPeriod && end > startPeriod)
        ) {
          this.calanders.controls[i].value[0] = '';

          this.calanders.controls[i].value[1] = '';
          this.calanders.controls[i].reset();
          this.calanders.controls[i].updateValueAndValidity();
          alert('over lapping dates selected, selected date range with you havent included already');
        }
      }
    }

  }

  dateSelected(date: Object) {

  }
  createForm() {
    this.calanderForm = this.formBuilder.group({
      calanders: this.formBuilder.array([
        this.formBuilder.group({
          order: [[new Date(), new Date()], Validators.required],
          active: [false]
        })])

    });
  }

  addPeriod() {
    this.calanders.push(this.formBuilder.group({
      order: [[new Date(), new Date()], Validators.required],
      active: [false]
    }));
  }

  get calanders(): FormArray {
    return this.calanderForm.get('calanders') as FormArray;
  }

  btnClick() {
    if (this.statusBtn.element.classList.contains('e-active')) {
      this.statusBtn.content = 'Deactiveated';
      this.statusBtn.iconCss = 'e-icons e-pause-icon';
      this.statusBtn.element.classList.remove('e-success');
      this.statusBtn.element.classList.remove('e-warning');
    } else {
      this.statusBtn.content = 'Active';
      this.statusBtn.iconCss = 'e-icons e-play-icon';
      this.statusBtn.element.classList.remove('e-warning');
      this.statusBtn.element.classList.add('e-success');
    }
  }
  onSubmit() {
    const form = this.calanders.controls;

    form.forEach(el => {

      this.calanderList.push({
        Start: el.value.order[0],
        End: el.value.order[1],
        Active: el.value.active
      });
    });

    this.calanderPeriodAPI.createCalanderPeriod(this.calanderList).subscribe(result => console.log(result));
  }
}
