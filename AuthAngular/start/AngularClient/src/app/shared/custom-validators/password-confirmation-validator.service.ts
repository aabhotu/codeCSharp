import { Injectable } from '@angular/core';
import { AbstractControl, ValidatorFn  } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PasswordConfirmationValidatorService {

  constructor() { }
  public validateConfirmPassword = (passwordControl : AbstractControl): ValidatorFn =>{
    return(confirmControl: AbstractControl): { [key: string]: boolean } | null =>{
      const confirmValue = confirmControl.value;
      const passwordValue = passwordControl.value;
      if(confirmValue==="")
        return;
      if(confirmValue != passwordValue)
        return {mustMatch: true}
      return null;
    }
  }
}
