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
///
  getCustomers(): Observable<Customer[]> {
    const options = { headers: this._header };
    return this.httpClient.get<Customer[]>(`${this.Url}`, options);
  }

  getCustomer(id: number): Observable<Customer> {
    const options = { headers: this._header };

    return this.httpClient.get<Customer>(`${this.Url}/${id}`, options);
  }

  addCustomer(newCustomer: Customer): Observable<Customer> {
    return this.httpClient.post<Customer>(`${this.Url}`, newCustomer)
      .pipe(
        catchError(this.handleError)
      );
  }

  updateCustomer(updatCustomer: Customer, id: number): Observable<Customer> {

    return this.httpClient.put<Customer>(`${this.Url}/${id}`, updatCustomer);
  }

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
    customer.set('Full_Name', userForm.Full_Name);
    customer.set('Account_ID', userForm.Account_ID);
    customer.set('Email', userForm.Email);
    customer.set('Phone_No', userForm.Phone_No);
    customer.set('Country', userForm.Country);
    customer.set('City', userForm.City);
    customer.set('SubCity', userForm.SubCity);
    customer.set('House_No', userForm.House_No);
    customer.set('Postal_Code', userForm.Postal_Code);
    customer.set('Date_Added', userForm.Date_Created.toISOString());
    customer.set('Date_Updated', userForm.Date_Updated.toISOString());
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
