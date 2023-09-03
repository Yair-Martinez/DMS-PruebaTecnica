import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ITareaRequest } from 'src/app/core/interfaces/ITareaRequest.interface';
import { ApiService } from 'src/app/core/services/api.service';
import { AuthApiService } from 'src/app/core/services/auth-api.service';
import { TasksDataService } from 'src/app/core/services/tasks-data.service';

@Component({
  selector: 'Task-Manager',
  templateUrl: './task-manager.component.html',
  styleUrls: ['./task-manager.component.scss']
})
export class TaskManagerComponent implements OnInit {

  private apiService = inject(ApiService);
  private tasksDataService = inject(TasksDataService);
  private fb = inject(FormBuilder);
  private authService = inject(AuthApiService);

  taskForm = this.fb.group({
    titulo: ["", [Validators.required]],
    descripcion: ["", [Validators.required]]
  });

  ngOnInit(): void {
    this.receiveTask();
  }

  receiveTask() {
    this.apiService.getTareas(this.authService.getUserId()!).subscribe(res => {
      console.log(res);
      this.tasksDataService.setTasks(res);
    });
  }

  sendTask() {
    if (this.taskForm.valid) {

      const tarea: ITareaRequest = {
        titulo: this.taskForm.value.titulo!,
        descripcion: this.taskForm.value.descripcion!,
        usuarioId: this.authService.getUserId()!
      };

      this.apiService.setTarea(tarea).subscribe(res => {
        this.receiveTask();
      });

      this.taskForm.reset();
    }
  }
}
