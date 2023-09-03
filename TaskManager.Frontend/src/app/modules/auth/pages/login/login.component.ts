import { Component, inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AuthApiService } from 'src/app/core/services/auth-api.service';

@Component({
  selector: 'Login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  private fb = inject(FormBuilder);
  private authService = inject(AuthApiService);

  loginForm = this.fb.group({
    email: [""],
    password: [""]
  });

  successMessage: string = "";
  errorMessage: string = "";


  ingresar() {
    const usuario = this.loginForm.value;
    console.log("Ingresar", usuario);
    this.successMessage = "";
    this.errorMessage = "";

    this.authService.signIn(usuario).subscribe(res => {
      console.log("📋 ~ file: login.component.ts:31 ~ LoginComponent ~ this.authService.signIn ~ res:", res)
      this.successMessage = "¡Usuario inició sesión exitosamente!";
    },
      (err) => {
        console.log("Error!:", err);
        this.errorMessage = err.error.error;
      });
  }
}
