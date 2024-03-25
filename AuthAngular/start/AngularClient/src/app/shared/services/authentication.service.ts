import { Injectable } from '@angular/core';
import { UserForRegistrationDto } from 'src/app/_interfaces/user/userForRegistrationDto.model';
import { RegistrationResponseDto } from 'src/app/_interfaces/response/registrationResponseDto.model';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';
import { UserForAuthenticationDto } from 'src/app/_interfaces/user/userForAuthenticationDto.model';
import { AuthResponseDto } from 'src/app/_interfaces/response/authResponseDto.model';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private authChangeSub = new Subject<boolean>();
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private jwtHelper: JwtHelperService) { }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) =>{
    this.authChangeSub.next(isAuthenticated);
  }
  
  public registerUser = (route:string, body: UserForRegistrationDto)=>{
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body)
  }

  public isUserAuthenticated = ():boolean => {
    const token = localStorage.getItem('token');
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  public loginUser =(route: string, body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(this.createCompleteRoute(route,this.envUrl.urlAddress), body)
  }
  public logout = () =>{
    localStorage.removeItem("token")
    this.sendAuthStateChangeNotification(false);
  }

  public isUserAdmin = ():boolean =>{
    const token = localStorage.getItem('token');
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']

    return role === 'Administrator';
  }
}
