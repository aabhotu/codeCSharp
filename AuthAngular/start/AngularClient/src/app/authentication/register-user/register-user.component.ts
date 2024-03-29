import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { UntypedFormControl, UntypedFormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { UserForRegistrationDto } from "src/app/_interfaces/user/userForRegistrationDto.model";
import { PasswordConfirmationValidatorService } from "src/app/shared/custom-validators/password-confirmation-validator.service";
import { AuthenticationService } from "src/app/shared/services/authentication.service";

@Component({
    selector: 'app-register-user',
    templateUrl: './register-user.component.html',
    styleUrls: ['./register-user.component.css']
})

export class RegisterUserComponent implements OnInit {
    registerForm: UntypedFormGroup;
    public errorMessage: string= '';
    public showError: boolean;

    constructor(private authService: AuthenticationService,private passConfValidator: PasswordConfirmationValidatorService, private router: Router){}
    
    ngOnInit(): void {
        this.registerForm = new UntypedFormGroup({
            firstName: new UntypedFormControl(''),
            lastName: new UntypedFormControl(''),
            email: new UntypedFormControl('', [Validators.required, Validators.email]),
            password: new UntypedFormControl('', [Validators.required]),
            confirm: new UntypedFormControl('')
        });
        this.registerForm.get('confirm').setValidators([Validators.required,
            this.passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
    }

    public validateControl = (controlName: string)=>{
        return this.registerForm.get(controlName).invalid && this.registerForm.get(controlName).touched;
    }

    public hasError = (controlName: string, errorName:string)=>{
        return this.registerForm.get(controlName).hasError(errorName);
    }

    public registerUser = (registerFormValue)=>{
        this.showError = false;
        const formValues = {...registerFormValue}

        const user: UserForRegistrationDto = {
            firstName: formValues.firstName,
            lastName: formValues.lastName,
            email: formValues.email,
            password: formValues.password,
            confirmPassword: formValues.confirm
        }
        this.authService.registerUser("api/accounts/registration", user)
            .subscribe({
                next: (_) => this.router.navigate(["/authenticaton/login"]),
                error: (err: HttpErrorResponse) =>{
                    this.errorMessage = err.message;
                    this.showError = true;
                }

            })
    }
}