import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
// import { RequestOptions } from '@angular/http';
import {Users} from './users';
import {map, catchError} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private Url = 'http://localhost/api/users';
  private _header = new HttpHeaders()
      .set(
        'Content-Type', 'application/json'
      );

  constructor(
    private httpClient: HttpClient
  ) { }

  getUsers(): Observable<Users> {
    return this.httpClient.get<Users>(`${this.Url}`)
            .pipe(
              // map(this.extractData),
              catchError(this.handleError)
            );
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
    const data = this.userData(newUser);
    const options = {headers: this._header};
    return this.httpClient.post<Users>(`${this.Url}`, data.toString(), options)
              .pipe(
               //  map(this.extractData),
                catchError(this.handleError)
              );
  }
  updateUser(updateUser: Users, id: number): Observable<Users> {
    const data = this.userData(updateUser);
    const options = {headers: this._header};
    return this.httpClient.put<Users>( `${this.Url}` + id, data.toString(), options)
              .pipe(
               //  map(this.extractData),
                catchError(this.handleError)
              );
  }

  deleteUser(id: number) {
      const options = { headers: this._header };
      return this.httpClient.delete(this.Url + '/' + id, options)
                .pipe(
                  map(success => success, 200),
                  catchError(this.handleError)
                );
  }

  userData(userForm: Users): URLSearchParams {
    const user = new URLSearchParams();
      user.set('First_Name', userForm.First_Name);
      user.set('Last_Name', userForm.Last_Name);
      user.set('Email', userForm.Email.toString());
      user.set('Password', userForm.Password.toString());
      user.set('Confirm_Password', userForm.Confirm_Password.toString());
      user.set('Account_Id', userForm.Account_Id.toString());
      user.set('Gender', userForm.Gender);
      user.set('Birth_Date', userForm.Birth_Date.toString());
      user.set('Date_Added', userForm.Date_Added.toString());
      user.set('Date _Updated', userForm.Date_Updated.toString());
    return user;
  }

  private extractData(res: Response) {
    const body = res.json();
          return body;
      }
  private handleError (error: Response | any) {
    console.error(error.message || error);
    return Observable.throw(error.status);
      }
}
