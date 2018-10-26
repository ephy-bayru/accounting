import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Exchangerate } from './exchange_rate';
import { map, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ExchangeRateService {
  URI = 'xrate';
  private _header = new HttpHeaders()
    .set(
      'Content-Type', 'application/json'
    );

  constructor(private httpClient: HttpClient) { }

  // ─── GET ALL EXCHANGE RATE FROM A SERVER ────────
  getRates(): Observable<Exchangerate[]> {
    const options = { headers: this._header };
    return this.httpClient.get<Exchangerate[]>(`${this.URI}`, options)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── GET AN EXCHANGE RATE FROM SERVER USING AN ID ───────
  getRate(id: number): Observable<Exchangerate> {
    const options = { headers: this._header };
    return this.httpClient.get<Exchangerate>(`${this.URI}/${id}`, options)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── ADD A NEW EXCHANGE RATE TO THE SERVER ──────────
  addRate(newRate: Exchangerate): Observable<Exchangerate> {
    const options = { headers: this._header };
    return this.httpClient.post<Exchangerate>(`${this.URI}`, newRate, options)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── UPDATING AN EXISTING EXCHANGE RATE USING ITS ID ─────────
  updateRate(updateRate: Exchangerate, id: number): Observable<Exchangerate> {
    return this.httpClient.put<Exchangerate>(`${this.URI}/${id}`, updateRate)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── DELETE A EXCHANGE RATE USING ITS ID ────────
  deleteCurrency(id: number) {
    const options = { headers: this._header };
    return this.httpClient.delete(`${this.URI}/${id}`, options)
      .pipe(
        map(success => success, 200),
        catchError(this.handleError)
      );
  }
  // ─── ERROR HANDLING FUNCTION ─────
  private handleError(error: Response | any) {
    if (error instanceof HttpErrorResponse) {
      console.error('backend error:', error.status);
      console.error('Response body:', error.message);
    } else {
      console.error('An error occured:', error.status);
    }
    return Observable.throw(error.status);
  }
}
