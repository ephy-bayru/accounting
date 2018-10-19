import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
// import { RequestOptions } from '@angular/http';
import { Customer } from './customer';
import { map, catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  Url = 'customers';
  private _header = new HttpHeaders()
    .set(
      'Content-Type', 'application/json'
    );
  constructor(
    private httpClient: HttpClient
  ) { }

// ─── GET ALL USERS FROM BACKEND ───────────────
  getCustomers(): Observable<Customer[]> {
    const options = { headers: this._header };
    return this.httpClient.get<Customer[]>(`${this.Url}`, options);
  }

// ─── GET A SINGLE CUSTOMER BY ITS ID FROM A BACKEND ──────────
  getCustomer(id: number): Observable<Customer> {
    const options = { headers: this._header };

    return this.httpClient.get<Customer>(`${this.Url}/${id}`, options);
  }

// ─── ADDING A NEW CUSTOMER ────────────────
  addCustomer(newCustomer: Customer): Observable<Customer> {
    return this.httpClient.post<Customer>(`${this.Url}`, newCustomer)
      .pipe(
        catchError(this.handleError)
      );
  }

// ─── UPDATING AN EXISTING CUSTOMER USING THEIR ID ─────────
  updateCustomer(updatCustomer: Customer, id: number): Observable<Customer> {

    return this.httpClient.put<Customer>(`${this.Url}/${id}`, updatCustomer);
  }

// ─── DELETING A CUSTOMER USING THEIR ID ─────────
  deleteCustomer(id: number) {
    const options = { headers: this._header };
    return this.httpClient.delete(`${this.Url}/${id}`, options)
      .pipe(
        map(success => success, 200),
        catchError(this.handleError)
      );
  }

  CustomerData(userForm: Customer): URLSearchParams {
    const customer = new URLSearchParams();
    customer.set('FullName', userForm.FullName);
    customer.set('Email', userForm.Email);
    customer.set('Phone_No', userForm.Phone_No);
    customer.set('Country', userForm.Country);
    customer.set('City', userForm.City);
    customer.set('SubCity', userForm.SubCity);
    customer.set('HouseNo', userForm.HouseNo);
    customer.set('PostalCode', userForm.PostalCode);
    return customer;
  }


  private handleError(error: Response | any) {
    // console.error(error.message || error);
    if (error instanceof HttpErrorResponse) {
      console.error('backend error:', error.status);
      console.error('Response body:', error.message);
    } else {
      console.error('An error occured:', error.message);
    }
    return Observable.throw(error.status);
  }
}
