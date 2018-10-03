import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AccountsService {
  private url = 'accounts';
  constructor(private httpClient: HttpClient) {

  }
  // Gets a single Account information by Id and returns an observable of Account
  getAccountById(id: string): Observable<Account> {
    return this.httpClient.get<Account>(`${this.url}/${id}`);
  }

  // Gets all the record of Account and returns and observable of Account object
  getAccountsList(): Observable<Account[]> {
    return this.httpClient.get<Account[]>(`${this.url}`);
  }

  // Creates a new instance of Account record in the system amd returns an observable
  // of the new Account information on success
  createAccountPeriod(newAccount: Account[]): Observable<Account[]> {
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    return this.httpClient.post<Account[]>(`${this.url}`, JSON.stringify(newAccount),
    config )
      .pipe(
        catchError(this.handleError)
      );
  }

  // Update a single instance of Account record and returns a boolean depending on the success or
  // failure of the operation
  updateAccount(id: number, updatedAccount: Account): Observable<boolean> {
    return this.httpClient.put<boolean>(`${this.url}/${id}`, updatedAccount)
      .pipe(
        catchError(this.handleError)
      );
  }

  // deletes a single instance of Account record and returns boolean based on the outcome of the operation
  deleteAccount(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: Response | any) {
    return Observable.throw(error.status);
  }

}
