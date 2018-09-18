import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable()
export class CalanderService {

  private url = 'calanders';
  constructor(private httpClient: HttpClient) {

  }
  // Gets a single organization information by Id and returns an observable of organization
  getCalanderById(id: number): Observable<CalanderPeriod> {
    return this.httpClient.get<CalanderPeriod>(`${this.url}/${id}`);
  }

  // Gets all the record of CalanderPeriod and returns and observable of CalanderPeriod object
  getCalanderPeriodsList(): Observable<CalanderPeriod[]> {
    return this.httpClient.get<CalanderPeriod[]>(`${this.url}`);
  }

  // Creates a new instance of CalanderPeriod record in the system amd returns an observable
  // of the new CalanderPeriod information on success
  createCalanderPeriod(newCalanderPeriod: CalanderPeriod): Observable<CalanderPeriod> {
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    return this.httpClient.post<CalanderPeriod>(`${this.url}`, JSON.stringify(newCalanderPeriod),
    config )
      .pipe(
        catchError(this.handleError)
      );
  }

  // Update a single instance of CalanderPeriod record and returns a boolean depending on the success or
  // failure of the operation
  updateCalanderPeriod(id: number, updatedCalanderPeriod: CalanderPeriod): Observable<boolean> {
    return this.httpClient.put<boolean>(`${this.url}/${id}`, updatedCalanderPeriod)
      .pipe(
        catchError(this.handleError)
      );
  }

  // deletes a single instance of CalanderPeriod record and returns boolean based on the outcome of the operation
  deleteCalanderPeriod(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: Response | any) {
    return Observable.throw(error.status);
  }

}


export class CalanderPeriod {
  id?: number;
  startDate: string;
  endDate: string;
  active: boolean;

}
