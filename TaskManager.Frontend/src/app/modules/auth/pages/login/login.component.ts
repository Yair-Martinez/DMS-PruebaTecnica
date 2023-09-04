import { Component, inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { IUsuarioLogin } from 'src/app/core/interfaces/IUsuarioLogin.interface';
import { AuthApiService } from 'src/app/core/services/auth-api.service';

@Component({
  selector: 'Login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  private fb = inject(FormBuilder);
  private authService = inject(AuthApiService);
  private router = inject(Router);

  loginForm = this.fb.group({
    email: [""],
    password: [""]
  });

  successMessage: string = "";
  errorMessage: string = "";


  ingresar() {
    const usuario: IUsuarioLogin = {
      email: this.loginForm.value.email!,
      password: this.loginForm.value.password!,
    };

    this.successMessage = "";
    this.errorMessage = "";

    this.authService.signIn(usuario).subscribe(res => {
      this.authService.setToken(res.token);
      this.authService.setUserId(res.usuarioId);
      this.successMessage = "¡Usuario inició sesión exitosamente!";

      this.router.navigate(["/task-manager"]);
    },
      (err) => {
        this.errorMessage = err.error.error;
      });
  }
}
