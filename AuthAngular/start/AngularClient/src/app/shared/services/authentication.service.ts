import { Injectable } from '@angular/core';
import { UserForRegistrationDto } from 'src/app/_interfaces/user/userForRegistrationDto.model';
import { RegistrationResponseDto } from 'src/app/_interfaces/response/registrationResponseDto.model';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';
import { UserForAuthenticationDto } from 'src/app/_interfaces/user/userForAuthenticationDto.model';
import { AuthResponseDto } from 'src/app/_interfaces/response/authResponseDto.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }
  
  public registerUser = (route:string, body: UserForRegistrationDto)=>{
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body)
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  public loginUser =(route: string, body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(this.createCompleteRoute(route,this.envUrl.urlAddress), body)
  }
}
