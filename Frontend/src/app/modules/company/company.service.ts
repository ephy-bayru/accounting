/*
 * @CreateTime: Sep 6, 2018 4:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 6, 2018 5:00 PM
 * @Description: Organization Service
 */
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class CompanyService {

  private url = 'organizations';
  constructor(private httpClient: HttpClient) {

  }
  // Gets a single organization information by Id and returns an observable of organization
  getOrganizationById(id: number): Observable<Organization> {
    return this.httpClient.get<Organization>(`${this.url}/${id}`);
  }

  // Gets all the record of organization and returns and observable of Organization object
  getOrganizationsList(): Observable<Organization[]> {
    return this.httpClient.get<Organization[]>(`${this.url}`);
  }

  // gets organization based on the location and returns an aray of organizations found there
  getOrganizationByLocation(location: string): Observable<Organization[]> {
    return this.httpClient.get<Organization[]>(`${this.url}/location`)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Creates a new instance of organization record in the system amd returns an observable
  // of the new organization information on success
  createOrganization(newOrganization: Organization): Observable<Organization> {
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    return this.httpClient.post<Organization>(`${this.url}`, JSON.stringify(newOrganization),
    config )
      .pipe(
        catchError(this.handleError)
      );
  }

  // Update a single instance of organization record and returns a boolean depending on the success or
  // failure of the operation
  updateOrganization(id: number, updatedOrganization: Organization): Observable<boolean> {
    return this.httpClient.put<boolean>(`${this.url}/${id}`, updatedOrganization)
      .pipe(
        catchError(this.handleError)
      );
  }

  // deletes a single instance of organization record and returns boolean based on the outcome of the operation
  deleteOrganization(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: Response | any) {
    return Observable.throw(error.status);
  }
}

// blue print of an organization data model id can be null depending on the operation at hand
// i.e for insert operation
export class Organization {
  id?: number;
  name: string;
  location: string;
  tin: string;
}
