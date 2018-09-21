import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpErrorResponse  } from '@angular/common/http';
// import { RequestOptions } from '@angular/http';
import {Users} from './users';
import {map, catchError} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UsersService {
   Url = 'employees';
  private _header = new HttpHeaders()
      .set(
        'Content-Type', 'application/json'
      );

  constructor(
    private httpClient: HttpClient
  ) { }

  getUsers(): Observable<Users[]> {
    const options = {headers: this._header};
    return this.httpClient.get<Users[]>(`${this.Url}`, options);
  }
  getUser(id: number): Observable<Users> {
    const options = {headers: this._header};
    console.log(`${this.Url}/{id}`);
    return this.httpClient.get<Users>(`${this.Url}/${id}`, options)
            .pipe(
             //  map(this.extractData),
              catchError(this.handleError)
            );
  }
  addUser(newUser: Users): Observable<Users> {
    return this.httpClient.post<Users>(`${this.Url}`, newUser)
              .pipe(
               //  map(this.extractData),
                catchError(this.handleError)
              );
  }
  updateUser(updateUser: Users, id: number): Observable<Users> {
    const data = this.userData(updateUser);
    const options = {headers: this._header};
    return this.httpClient.put<Users>(`${this.Url}/${id}`, data.toString(), options)
              .pipe(
               //  map(this.extractData),
                catchError(this.handleError)
              );
  }

  deleteUser(id: number) {
      const options = { headers: this._header };
      return this.httpClient.delete(`${this.Url}/${id}`, options)
                .pipe(
                  map(success => success, 200),
                  catchError(this.handleError)
                );
  }

  userData(userForm: Users): URLSearchParams {
    const user = new URLSearchParams();
      user.set('First_Name', userForm.First_Name);
      user.set('Last_Name', userForm.Last_Name);
      user.set('Email', userForm.Email);
      user.set('Password', userForm.Password);
      user.set('Confirm_Password', userForm.Confirm_Password);
      user.set('Account_Id', userForm.Account_Id);
      user.set('Gender', userForm.Gender);
      user.set('Birth_Date', userForm.Birth_Date.toISOString());
    return user;
  }

  private extractData(res: Response) {
    const body = res.json();
          return body;
      }
  private handleError (error: Response | any) {
    // console.error(error.message || error);
    if (error instanceof HttpErrorResponse) {
      console.error('backend error:', error.status);
      console.error('Response body:', error.message);
    }  else {
      console.error('An error occured:', error.message);
    }
    return Observable.throw(error.status);
      }
}
