import { Component, OnInit, inject } from '@angular/core';
import { ApiService } from 'src/app/core/services/api.service';
import { TasksDataService } from 'src/app/core/services/tasks-data.service';

@Component({
  selector: 'Task-Manager',
  templateUrl: './task-manager.component.html',
  styleUrls: ['./task-manager.component.scss']
})
export class TaskManagerComponent implements OnInit {

  private apiService = inject(ApiService);
  private tasksDataService = inject(TasksDataService);

  ngOnInit(): void {
    this.apiService.getTareas().subscribe(res => {
      console.log(res);
      this.tasksDataService.setTasks(res);
    });
  }

}
