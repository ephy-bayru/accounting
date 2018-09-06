/*
 * @CreateTime: Sep 6, 2018 4:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 6, 2018 4:49 PM
 * @Description: Modify Here, Please
 */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormOptionsComponent } from './form-options.component';

describe('FormOptionsComponent', () => {
  let component: FormOptionsComponent;
  let fixture: ComponentFixture<FormOptionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormOptionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
