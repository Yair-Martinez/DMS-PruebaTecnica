import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ITareaResponse } from '../interfaces/ITareaResponse.interface';
import { ITareaRequest } from '../interfaces/ITareaRequest.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }


  getTareas(): Observable<Array<ITareaResponse>> {
    return this.http.get<Array<any>>(this.apiUrl + "/Tarea");
  }

  getTarea(id: string): Observable<ITareaResponse> {
    return this.http.get<ITareaResponse>(this.apiUrl + "/Tarea/" + id);
  }

  setTarea(tarea: ITareaRequest): Observable<ITareaResponse> {
    return this.http.post<ITareaResponse>(this.apiUrl + "/Tarea", tarea);
  }

}
