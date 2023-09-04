import { Component, inject } from '@angular/core';
import { AuthApiService } from './core/services/auth-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TaskManager.Frontend';

  private authService = inject(AuthApiService);

  get showLogout(): boolean {
    return this.authService.isLoggedIn();
  }
}
