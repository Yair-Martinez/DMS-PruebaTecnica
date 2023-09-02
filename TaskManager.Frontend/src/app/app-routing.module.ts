import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "task-manager",
    loadChildren: () => import('./modules/task-manager/task-manager.module').then(m => m.TaskManagerModule)
  },
  {
    path: "",
    redirectTo: "task-manager",
    pathMatch: "full"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
