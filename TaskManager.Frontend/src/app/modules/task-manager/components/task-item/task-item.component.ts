import { Component, Input, inject } from '@angular/core';
import { ITareaResponse } from 'src/app/core/interfaces/ITareaResponse.interface';
import { ApiService } from 'src/app/core/services/api.service';
import { AuthApiService } from 'src/app/core/services/auth-api.service';

@Component({
  selector: 'Task-Item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.scss']
})
export class TaskItemComponent {

  private apiService = inject(ApiService);
  private authService = inject(AuthApiService);

  @Input() tarea = {} as ITareaResponse;

  get isComplete(): boolean {
    return this.tarea.estado === "Completada";
  }

  checkInput() {
    this.tarea.estado = this.tarea.estado === "Completada" ? "Pendiente" : "Completada";

    const task = Object.assign({}, this.tarea, { usuarioId: this.authService.getUserId() });
    task.estado = this.isComplete ? "Completada" : "Pendiente";

    this.apiService.updateTarea(task).subscribe();
  }

}
