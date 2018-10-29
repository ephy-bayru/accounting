import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Currency } from './currency';
import { map, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  URI = 'currency';
  private _header = new HttpHeaders()
    .set(
      'Content-Type', 'application/json'
    );

  constructor(private httpClient: HttpClient) { }

  // ─── GET ALL CURRENCIES FROM A SERVER ────────
  getCurrencies(): Observable<Currency[]> {
    const options = { headers: this._header };
    return this.httpClient.get<Currency[]>(`${this.URI}`, options)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── GET A CURRENCIES FROM SERVER USING AN ID ───────
  getCurrency(id: number): Observable<Currency> {
    const options = { headers: this._header };
    return this.httpClient.get<Currency>(`${this.URI}/${id}`, options)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── ADD A NEW CURRENCIES TO THE SERVER ──────────
  addCurrency(newUser: Currency): Observable<Currency> {
    const options = { headers: this._header };
    return this.httpClient.post<Currency>(`${this.URI}`, newUser, options)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── UPDATING AN EXISTING CURRENCIES USING ITS ID ─────────
  updateCurrency(updateUser: Currency, id: number): Observable<Currency> {
    return this.httpClient.put<Currency>(`${this.URI}/${id}`, updateUser)
      .pipe(
        map(
          success => success, 200),
        catchError(this.handleError)
      );
  }

  // ─── DELETE A CURRENCIES USING ITS ID ────────
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
