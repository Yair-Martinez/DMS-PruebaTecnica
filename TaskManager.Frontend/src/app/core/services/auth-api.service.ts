import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IUsuarioRegister } from '../interfaces/IUsuarioRegister.interface';
import { IUsuarioLogin } from '../interfaces/IUsuarioLogin.interface';
import { IUsuarioResponse } from '../interfaces/IUsuarioResponse.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) { }

  //API-AUTH
  signUp(usuario: IUsuarioRegister): Observable<any> {
    return this.http.post(this.apiUrl + "/Usuario/register", usuario);
  }

  signIn(usuario: IUsuarioLogin): Observable<IUsuarioResponse> {
    return this.http.post<IUsuarioResponse>(this.apiUrl + "/Usuario/login", usuario);
  }


  //TOKEN HANDLERS
  signOut() {
    localStorage.clear();
    this.router.navigate(['auth/login'])
  }

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  

  setUserId(userId: string) {
    localStorage.setItem('userId', userId);
  }

  getUserId() {
    return localStorage.getItem('userId');
  }

}
