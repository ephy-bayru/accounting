import { Directive, Input } from '@angular/core';
import { Validator, AbstractControl, ValidationErrors, NG_VALIDATORS } from '@angular/forms';
import { Subscription } from 'rxjs';


@Directive({
  selector: '[appCompare]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: CompareDirective,
      multi: true
    }
  ]
})
export class CompareDirective implements Validator {

  @Input() controlName: string;

  validate(input: AbstractControl): ValidationErrors | null {
    if (input.value === null || input.value.length === 0) {
      return null;
    }
    const controlToCompare = input
      .root
      .get(this.controlName);
    if (controlToCompare) {
      const subscription: Subscription = controlToCompare
        .valueChanges
        .subscribe(() => {
          input.updateValueAndValidity();
          subscription.unsubscribe();
        });
    }
    return controlToCompare && controlToCompare.value !== input.value
      ? {
        'match': true
      }
      : null;
  }

}
