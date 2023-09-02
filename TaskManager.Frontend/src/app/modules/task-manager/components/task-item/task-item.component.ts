import { Component, Input } from '@angular/core';
import { ITareaResponse } from 'src/app/core/interfaces/ITareaResponse.interface';

@Component({
  selector: 'Task-Item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.scss']
})
export class TaskItemComponent {

  @Input() tarea = {} as ITareaResponse;

}
