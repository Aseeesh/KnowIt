import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment as env } from "../../environments/environment";
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { EventModel as _model } from './model/event';
import { GenericResponse } from '../auth/models/GenericResponse';

@Injectable({ providedIn: 'root' })
export class EventService {
    private _apiURL =env.base_API_Url+ "api/EventDetail";
    constructor(private http: HttpClient) { }
    _getMultiples(): Observable<_model[]> { 
      return this.http.get<_model[]>(`${this._apiURL}`, 
      );
    }
  
      _getById(id: string): Observable<_model> { 
        return this.http.get<_model>(`${this._apiURL}/${id}`, 
          //{headers: {'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'}}
        );
      }
      _updateService(_model: _model): Observable<_model> { 
        return this.http.put<_model>(
          `${this._apiURL}/${_model.id}`, _model 
        );
      } 
  
      _addService(_model: _model): Observable<_model> { 
        return   this.http.post<_model>(  `${this._apiURL}`,  _model); 
       
      } 
      
      
  
    _deleteService(id: string) {
        return this.http.delete( `${this._apiURL}/${id}`);
    }
}