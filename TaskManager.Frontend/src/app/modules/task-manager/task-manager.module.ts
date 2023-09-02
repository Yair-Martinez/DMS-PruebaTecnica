import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskManagerRoutingModule } from './task-manager-routing.module';
import { TaskManagerComponent } from './task-manager.component';


@NgModule({
  declarations: [
    TaskManagerComponent
  ],
  imports: [
    CommonModule,
    TaskManagerRoutingModule
  ]
})
export class TaskManagerModule { }
