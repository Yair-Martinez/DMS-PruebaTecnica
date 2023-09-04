import { Component, inject } from '@angular/core';
import { AuthApiService } from 'src/app/core/services/auth-api.service';

@Component({
  selector: 'Btn-Logout',
  templateUrl: './btn-logout.component.html',
  styleUrls: ['./btn-logout.component.scss']
})
export class BtnLogoutComponent {

  private authService = inject(AuthApiService);


  logout() {
    this.authService.signOut();
  }
}
