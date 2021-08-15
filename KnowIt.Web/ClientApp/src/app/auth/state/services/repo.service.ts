import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ErrorService } from 'src/app/core/state/services';
import { Router } from '@angular/router';
import { GenericResponse } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class PostService {
    constructor(
        private httpClient: HttpClient,
        private errorService: ErrorService,
        private router: Router
    ) {}
  private readonly APIUrl = environment.API_URL + 'posts';
 

  getList(page: number, count: number): Observable<any[]> {
    let params = new HttpParams()
			.set('page', page.toString())
			.set('count', count.toString());

    return this.httpClient.get<any[]>(`/${this.APIUrl}}?${params.toString()}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  get(id: string | number): Observable<any> {
    return this.httpClient.get<any>(`/${this.APIUrl}}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  add(post: any): Observable<any> {
    return this.httpClient.post(`/${this.APIUrl}}`, post)
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(id: string | number): Observable<any> {
    return this.httpClient.delete(`/${this.APIUrl}}/${id}`) 
      .pipe(
        catchError(this.handleError)
      );
  }

  update(post: any) {
    return this.httpClient.put(`/${this.APIUrl}}`,post)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  private handleError(error: HttpErrorResponse) {
    // Handle the HTTP error here
    return throwError('Something wrong happened');
  }
}