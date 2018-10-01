import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Suppliers } from './suppliers';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {
  Url = 'suppliers';
  private _header = new HttpHeaders()
    .set(
      'Content-Type', 'application/json'
    );

  constructor(
    private httpClient: HttpClient
  ) { }

  getSuppliers(): Observable<Suppliers[]> {
    const options = { headers: this._header };
    return this.httpClient.get<Suppliers[]>(`${this.Url}`, options);
  }
  getSupplier(id: number): Observable<Suppliers> {
    const options = { headers: this._header };

    return this.httpClient.get<Suppliers>(`${this.Url}/${id}`, options);
  }
  addSupplier(newSupplier: Suppliers): Observable<Suppliers> {
    return this.httpClient.post<Suppliers>(`${this.Url}`, newSupplier)
      .pipe(
        catchError(this.handleError)
      );
  }
  updateSupplier(updatesupplier: Suppliers, id: number): Observable<Suppliers> {

    return this.httpClient.put<Suppliers>(`${this.Url}/${id}`, updatesupplier);
  }

  deleteSupplier(id: number) {
    const options = { headers: this._header };
    return this.httpClient.delete(`${this.Url}/${id}`, options)
      .pipe(
        map(success => success, 200),
        catchError(this.handleError)
      );
  }

  supplierData(supplierForm: Suppliers): URLSearchParams {
    const supplier = new URLSearchParams();
    supplier.set('Full_Name', supplierForm.Full_Name);
    supplier.set('Account_Number', supplierForm.Account_Number);
    supplier.set('Email', supplierForm.Email);
    supplier.set('Phone_No', supplierForm.Phone_No);
    supplier.set('Account_Id', supplierForm.Account_id);
    supplier.set('Country', supplierForm.Country);
    supplier.set('City', supplierForm.City);
    supplier.set('SubCity', supplierForm.SubCity);
    supplier.set('House_No', supplierForm.House_No);
    supplier.set('Postal_Code', supplierForm.Postal_Code);

    return supplier;
  }

  private handleError(error: Response | any) {
    if (error instanceof HttpErrorResponse) {
      console.error('backend error:', error.status);
      console.error('Response body:', error.message);
    } else {
      console.error('An error occured:', error.message);
    }
    return Observable.throw(error.status);
  }
}
