import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { NotFoundComponent } from './shared/pages/not-found/not-found.component';

const routes: Routes = [
  {
    path: "auth",
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: "task-manager",
    loadChildren: () => import('./modules/task-manager/task-manager.module').then(m => m.TaskManagerModule),
    canActivate: [authGuard]
  },
  {
    path: "not-found",
    component: NotFoundComponent
  },
  {
    path: "",
    redirectTo: "auth",
    pathMatch: "full"
  },
  {
    path: "**",
    redirectTo: "not-found",
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
