import { Component, inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { ITareaResponse } from 'src/app/core/interfaces/ITareaResponse.interface';
import { TasksDataService } from 'src/app/core/services/tasks-data.service';

@Component({
  selector: 'Task-List',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent {

  private tasksDataService = inject(TasksDataService);

  tareas$: BehaviorSubject<Array<ITareaResponse>> = this.tasksDataService.getTasks();

}
