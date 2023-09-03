import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  signUp(usuario: any) {
    return this.http.post(this.apiUrl + "/Usuario/register", usuario);
  }
  
  signIn(usuario: any) {
    return this.http.post(this.apiUrl + "/Usuario/login", usuario);
  }
}
