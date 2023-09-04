import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ITareaResponse } from '../interfaces/ITareaResponse.interface';

@Injectable({
  providedIn: 'root'
})
export class TasksDataService {

  private tasks$ = new BehaviorSubject<Array<ITareaResponse>>([]);
  private filtro$ = new BehaviorSubject<string>("");

  constructor() { }

  getTasks() {
    return this.tasks$;
  }

  setTasks(tareas: ITareaResponse[]) {
    return this.tasks$.next(tareas);
  }

  //Filtro
  getFiltro() {
    return this.filtro$;
  }

  setFiltro(filtro: string) {
    this.filtro$.next(filtro);
  }
}
