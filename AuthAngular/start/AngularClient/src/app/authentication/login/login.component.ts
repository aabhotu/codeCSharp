import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, FormControlName, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthResponseDto } from 'src/app/_interfaces/response/authResponseDto.model';
import { UserForAuthenticationDto } from 'src/app/_interfaces/user/userForAuthenticationDto.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private returnUrl: string
  loginForm: UntypedFormGroup;
  errorMessage: string ='';
  showError: boolean;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = new UntypedFormGroup({
      username: new UntypedFormControl("", [Validators.required]),
      password: new UntypedFormControl("", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/'
  }
  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName).invalid && this.loginForm.get(controlName).touched
  }
  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName).hasError(errorName)
  }
  loginUser = (loginFormValue) =>{
    this.showError = false;
    const login = {...loginFormValue}

    const userForAuth: UserForAuthenticationDto = {
      email: login.username,
      password: login.password
    }
    this.authService.loginUser('api/accounts/login', userForAuth)
      .subscribe({
        next: (res:AuthResponseDto) =>{
          localStorage.setItem('token', res.token);
          this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
          this.router.navigate([this.returnUrl]);
        },
        error: (err: HttpErrorResponse) =>{
          this.errorMessage = err.message;
          this.showError = true;
        }
      })
  }

}
