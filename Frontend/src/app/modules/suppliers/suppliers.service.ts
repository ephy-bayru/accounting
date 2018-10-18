import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Suppliers } from './suppliers';
import { map, catchError } from 'rxjs/operators';
import { Subject } from 'rxjs/Subject';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {
  Url = 'suppliers';
  supp = new Subject<Suppliers[]>();
  private _header = new HttpHeaders()
    .set(
      'Content-Type', 'application/json'
    );

  constructor(
    private httpClient: HttpClient
  ) { }

// ─── GET ALL SUPPLIERS FROM BACKEND ────────────
  getSuppliers(): Observable<Suppliers[]> {
    const options = { headers: this._header };
    return this.httpClient.get<Suppliers[]>(`${this.Url}`, options);
  }

// ─── GET A SINGLE SUPPLIER FROM A BACKEND USING SUPPLIER ID ───────
  getSupplier(id: number): Observable<Suppliers> {
    const options = { headers: this._header };

    return this.httpClient.get<Suppliers>(`${this.Url}/${id}`, options);
  }

// ─── ADD A NEW SUPPLIER ───────────────
  addSupplier(newSupplier: Suppliers): Observable<Suppliers> {
    return this.httpClient.post<Suppliers>(`${this.Url}`, newSupplier)
      .pipe(
        catchError(this.handleError)
      );
  }


// ─── UPDATE AN EXISTING SUPPLIER USING ITS ID ───────
  updateSupplier(updatesupplier: Suppliers, id: number): Observable<Suppliers> {

    return this.httpClient.put<Suppliers>(`${this.Url}/${id}`, updatesupplier);
  }

// ─── DELETE A SUPPLIER USING ITS ID ────────
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
    supplier.set('Full_Name', supplierForm.FullName);
    supplier.set('Email', supplierForm.Email);
    supplier.set('Phone_No', supplierForm.Phone_No);
    supplier.set('Country', supplierForm.Country);
    supplier.set('City', supplierForm.City);
    supplier.set('SubCity', supplierForm.SubCity);
    supplier.set('House_No', supplierForm.HouseNo);
    supplier.set('Postal_Code', supplierForm.PostalCode);

    return supplier;
  }

// ─── ERROR HANDLING FUNCTION THAT RETURNS ERROR MESSAGE WHEN EVER ERRORS OCCURS FROM A BACKEND SERVER
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
