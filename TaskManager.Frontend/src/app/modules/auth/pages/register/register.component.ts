import { Component, inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { IUsuarioRegister } from 'src/app/core/interfaces/IUsuarioRegister.interface';
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
    const usuario: IUsuarioRegister = {
      nombre: this.registerForm.value.nombre!,
      apellido: this.registerForm.value.apellido!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
    };

    this.successMessage = "";
    this.errorMessage = "";

    this.authService.signUp(usuario).subscribe(res => {
      this.successMessage = "¡Usuario registrado exitosamente!";
    },
      (err) => {
        console.log("Error!:", err);
        this.errorMessage = err.error.error;
      });
  }
}
