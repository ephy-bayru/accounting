/*
 * @CreateTime: Sep 6, 2018 4:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 6, 2018 4:53 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comapny-form',
  templateUrl: './comapny-form.component.html',
  styleUrls: ['./comapny-form.component.css']
})
export class ComapnyFormComponent implements OnInit {


  organizationForm: FormGroup;
      constructor(private formBuilder: FormBuilder, private activatedRoute: ActivatedRoute) {
             this.organizationForm = this.formBuilder.group({
                Name: '',
                Location: '',
                Tin: ''
              });
      }

  ngOnInit(): void {
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
            () => {ele.classList.remove('e-input-btn-ripple'); },
            500);
}

onSubmit()  {
   }

}
