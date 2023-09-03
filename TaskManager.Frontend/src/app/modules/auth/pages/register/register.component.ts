import { Component, inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AuthApiService } from 'src/app/core/services/auth-api.service';

@Component({
  selector: 'Register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  private fb = inject(FormBuilder);
  private authService = inject(AuthApiService);

  registerForm = this.fb.group({
    nombre: [""],
    apellido: [""],
    email: [""],
    password: [""]
  });

  successMessage: string = "";
  errorMessage: string = "";


  registrar() {
    const usuario = this.registerForm.value;
    console.log("Registrar", usuario);
    this.successMessage = "";
    this.errorMessage = "";

    this.authService.signUp(usuario).subscribe(res => {
      console.log("📋 ~ file: register.component.ts:28 ~ RegisterComponent ~ this.authService.signUp ~ res:", res)
      this.successMessage = "¡Usuario registrado exitosamente!";
    },
      (err) => {
        console.log("Error!:", err);
        this.errorMessage = err.error.error;
      });
  }
}
