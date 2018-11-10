import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Suppliers } from './suppliers';
import 'rxjs/add/observable/of';


@Injectable({
  providedIn: 'root'
})
export class SuppliersMockService {

  constructor() { }

public getSuppliers(): Observable<Suppliers[]> {
  return Observable.of([
    new Suppliers({
      id: 1,
      FullName: 'Dell',
      Email: 'dell@gmail.com',
      PhoneNo: '0921204589',
      Country: 'Ethiopia',
      City: 'Adis',
      SubCity: 'Piasa',
      HouseNo: '2018',
      PostalCode: '1234',
      Balance: 1000,
      Active: 'true',
    })
  ]);
}

public getSupplier(id: number): Observable<Suppliers> {
  return Observable.of(
    new Suppliers({
      id: 1,
      FullName: 'Dell',
      Email: 'dell@gmail.com',
      PhoneNo: '0921204589',
      Country: 'Ethiopia',
      City: 'Adis',
      SubCity: 'Piasa',
      HouseNo: '2018',
      PostalCode: '1234',
      Balance: 1000,
      Active: 'true',
    }) );
}

public addSupplier(newSupplier: Suppliers): Observable<Suppliers> {
   return Observable.of(
    new Suppliers({
      id: 1,
      FullName: 'Dell',
      Email: 'dell@gmail.com',
      PhoneNo: '0921204589',
      Country: 'Ethiopia',
      City: 'Adis',
      SubCity: 'Piasa',
      HouseNo: '2018',
      PostalCode: '1234',
      Balance: 1000,
      Active: 'true',
    }) );
}


public updateSupplier(updatesupplier: Suppliers, id: number): Observable<Suppliers> {
  return Observable.of(
    new Suppliers({
      id: 1,
      FullName: 'Dell',
      Email: 'dell@gmail.com',
      PhoneNo: '0921204589',
      Country: 'Ethiopia',
      City: 'Adis',
      SubCity: 'Piasa',
      HouseNo: '2018',
      PostalCode: '1234',
      Balance: 1000,
      Active: 'true',
    })
  );
}

public deleteSupplier(id: number) {
  return null;
}


}
