import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ITareaResponse } from '../interfaces/ITareaResponse.interface';

@Injectable({
  providedIn: 'root'
})
export class TasksDataService {

  private tasks$ = new BehaviorSubject<Array<ITareaResponse>>([]);

  constructor() { }

  getTasks() {
    return this.tasks$;
  }

  setTasks(tareas: ITareaResponse[]) {
    return this.tasks$.next(tareas);
  }
}
