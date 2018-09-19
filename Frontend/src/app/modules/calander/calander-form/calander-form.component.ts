import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';

@Component({
  selector: 'app-calander-form',
  templateUrl: './calander-form.component.html',
  styleUrls: ['./calander-form.component.css']
})
export class CalanderFormComponent implements OnInit {
  calanderForm: FormGroup;

  @ViewChild('statusBtn') statusBtn: ButtonComponent;

  constructor(private formBuilder: FormBuilder) {
    this.createForm();
  }

  ngOnInit() {
  }

  createForm() {
    this.calanderForm = this.formBuilder.group({
      calanders: this.formBuilder.array([
        this.formBuilder.control('', Validators.required)
      ])
    });
  }

  addPeriod() {
    this.calanders.push(this.formBuilder.control('', Validators.required));
  }

  get calanders(): FormArray {
    return this.calanderForm.get('calanders') as FormArray;
  }

  btnClick() {
    if (this.statusBtn.element.classList.contains('e-active')) {
      this.statusBtn.content = 'Deactiveated';
      this.statusBtn.iconCss = 'e-icons e-pause-icon';
      this.statusBtn.element.classList.replace('e-success', 'e-warning');
    } else {
      this.statusBtn.content = 'Active';
      this.statusBtn.iconCss = 'e-icons e-play-icon';
      this.statusBtn.element.classList.replace('e-warning', 'e-success');
    }
  }
  onSubmit() {
    const form = this.calanderForm.value;
    console.log(form);
  }
}
