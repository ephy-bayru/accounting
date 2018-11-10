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

   // ─── SETTING THE HTTP REQUEST HEADER ─────────
  private _header = new HttpHeaders()
      .set(
        'Content-Type', 'application/json'
      );

  constructor(
    private httpClient: HttpClient
  ) { }

// ─── GET ALL USERS FROM A SERVER ────────
  getUsers(): Observable<Users[]> {
    const options = {headers: this._header};
    return this.httpClient.get<Users[]>(`${this.Url}`, options);
  }

// ─── GET A USER FROM SERVER USING AN ID ───────
  getUser(id: number): Observable<Users> {
    const options = {headers: this._header};

    return this.httpClient.get<Users>(`${this.Url}/${id}`, options);
  }

// ─── ADD A NEW USER TO THE SERVER ──────────
  addUser(newUser: Users): Observable<Users> {
    return this.httpClient.post<Users>(`${this.Url}`, newUser)
              .pipe(
               //  map(this.extractData),
                catchError(this.handleError)
              );
  }

// ─── UPDATING AN EXISTING USER USING ITS ID ─────────
  updateUser(updateUser: Users, id: number): Observable<Users> {

    return this.httpClient.put<Users>(`${this.Url}/${id}`, updateUser);
  }

// ─── DELETE A USRE USING ITS ID ─────────────
  deleteUser(id: number) {
      const options = { headers: this._header };
      return this.httpClient.delete(`${this.Url}/${id}`, options)
                .pipe(
                  map(success => success, 200),
                  catchError(this.handleError)
                );
  }

  // userData(userForm: Users): URLSearchParams {
  //   const user = new URLSearchParams();
  //     user.set('FirstName', userForm.FirstName);
  //     user.set('LastName', userForm.LastName);
  //     user.set('Email', userForm.Email);
  //     user.set('PhoneNo', userForm.Phone_No);
  //     user.set('Password', userForm.Password);
  //     user.set('Confirm_Password', userForm.Confirm_Password);
  //     user.set('Gender', userForm.Gender);
  //     user.set('Birth_Date', userForm.Birth_Date.toISOString());
  //   return user;
  // }

  private extractData(res: Response) {
    const body = res.json();
          return body;
      }

      // ─── ERROR HANDLING FUNCTION ─────────────
  private handleError (error: Response | any) {
    if (error instanceof HttpErrorResponse) {
      console.error('backend error:', error.status);
      console.error('Response body:', error.message);
    }  else {
      console.error('An error occured:', error.message);
    }
    return Observable.throw(error.status);
      }
}
