import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskManagerRoutingModule } from './task-manager-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

import { TaskManagerComponent } from './task-manager.component';
import { TaskListComponent } from './components/task-list/task-list.component';
import { TaskItemComponent } from './components/task-item/task-item.component';


@NgModule({
  declarations: [
    TaskManagerComponent,
    TaskListComponent,
    TaskItemComponent
  ],
  imports: [
    CommonModule,
    TaskManagerRoutingModule,
    ReactiveFormsModule
  ]
})
export class TaskManagerModule { }
