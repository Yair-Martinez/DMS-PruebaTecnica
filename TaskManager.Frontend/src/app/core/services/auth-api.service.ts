import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) { }

  //API-AUTH
  signUp(usuario: any): Observable<any> {
    return this.http.post(this.apiUrl + "/Usuario/register", usuario);
  }

  signIn(usuario: any): Observable<any> {
    return this.http.post(this.apiUrl + "/Usuario/login", usuario);
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
