import { Pipe, PipeTransform } from '@angular/core';
import { ITareaResponse } from '../interfaces/ITareaResponse.interface';

@Pipe({
  name: 'filtroTareas'
})
export class FiltroTareasPipe implements PipeTransform {

  transform(tareas: ITareaResponse[], estado: string): ITareaResponse[] {
    /* return tareas.filter(tarea => tarea.estado === estado); */
    switch (estado) {
      case "Pendiente":
      case "Completada":
        return tareas.filter(tarea => tarea.estado === estado);
      default:
        return tareas.filter(tarea => tarea.estado === tarea.estado);
    }
  }

}
