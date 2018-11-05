import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Accounts } from './accounts';

@Injectable()
export class AccountsService {
  private url = 'accounts';
  constructor(private httpClient: HttpClient) {

  }
  // Gets a single Account information by Id and returns an observable of Account
  getAccountById(id: string): Observable<Accounts> {
    return this.httpClient.get<Accounts>(`${this.url}/${id}`);
  }

  // Gets all the record of Account and returns and observable of Account object
  getAccountsList(): Observable<Accounts[]> {
    return this.httpClient.get<Accounts[]>(`${this.url}`);
  }

  // Creates a new instance of Account record in the system amd returns an observable
  // of the new Account information on success
  createAccount(newAccount: Accounts): Observable<Accounts> {
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    return this.httpClient.post<Accounts>(`${this.url}`, newAccount )
      .pipe(
        catchError(this.handleError)
      );
  }

  // Update a single instance of Account record and returns a boolean depending on the success or
  // failure of the operation
  updateAccount(id: string, updatedAccount: Accounts): Observable<boolean> {
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
