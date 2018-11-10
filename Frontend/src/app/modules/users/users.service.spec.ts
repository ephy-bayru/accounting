import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed, getTestBed, inject } from '@angular/core/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { UsersService } from './users.service';
import { Users } from './users';

describe('UserService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [UsersService]
    });
  });

  afterEach(inject([HttpTestingController],
    (httpMock: HttpTestingController) => {
    httpMock.verify();
  }));

  describe('getting all users', () => {
    it('returns users with an id <= 5',
      inject([HttpClient, HttpTestingController],
        (
          http: HttpClient,
          httpMock: HttpTestingController
          ) => {
        const mockResponse = [
          {
            id: 5,
            FirstName: 'Ephrem',
            LastName: 'Bayru',
            Email: 'ephy@gmail.com',
            Phone_No: 0920208549,
            Password: 123456,
            Confirm_Password: 123456,
            Gender: 'm',
            Birth_Date: 2018
          },
          {
            id: 6,
            FirstName: 'Mike',
            LastName: 'Araya',
            Email: 'mike@gmail.com',
            Phone_No: 0920208549,
            Password: 123456,
            Confirm_Password: 123456,
            Gender: 'f',
            Birth_Date: 2018
          }
        ];

        const usersService = getTestBed().get(UsersService);
        usersService.getUsers().subscribe(
          actualUsers => {
            expect(actualUsers.length).toBe(1);
            expect(actualUsers[0].id).toEqual(5);
          }
        );
        const req = httpMock.expectOne(usersService.Url);
        expect(req.request.method).toEqual('GET');

        req.flush(mockResponse);
        httpMock.verify();
      }));

    it('returns User[] mapped to correct properties', inject([HttpClient, HttpTestingController],
      (http: HttpClient, httpMock: HttpTestingController) => {
        const mockResponse = [
          {
            id: 1,
            FirstName: 'Mike',
            LastName: 'Araya',
            Email: 'mike@gmail.com',
            Phone_No: '0920208549',
            Password: '123456',
            Confirm_Password: '123456',
            Gender: 'f',
            Birth_Date: 2018
          }
        ];

        const expectedResults: Users[] = [
          {
            id: 6,
            FirstName: 'Mike',
            LastName: 'Araya',
            Email: 'mike@gmail.com',
            Phone_No: '0920208549',
            Password: '123456',
            Confirm_Password: '123456',
            Gender: 'f',
            Birth_Date: 2018
          }
        ];

        const usersService = getTestBed().get(UsersService);
        usersService.getUsers().subscribe(
          actualResults => {
            expect(actualResults).toEqual(expectedResults);
          }
        );

        const req = httpMock.expectOne(usersService.Url);
        expect(req.request.method).toEqual('GET');

        req.flush(mockResponse);
        httpMock.verify();
      }));

    it('should throw with an error message when API returns an error',
      inject([HttpClient, HttpTestingController],
        (http: HttpClient, httpMock: HttpTestingController) => {
        const userService = getTestBed().get(UsersService);
        userService.getUsers().subscribe(
          response => fail('should have failed with 500 status'),
          (error: HttpErrorResponse) => {
            expect(error).toBeTruthy();
            expect(error.status).toEqual(500);
          }
        );

        const req = httpMock.expectOne(userService.apiEndpoint);
        expect(req.request.method).toEqual('GET');

        req.flush({ errorMessage: 'Error!' },
        { status: 500, statusText: 'Server Error' });
        httpMock.verify();
      }));
  });

  describe('adding a new user', () => {
    it('returns the newly added user',
      inject([HttpClient, HttpTestingController],
        (http: HttpClient, httpMock: HttpTestingController) => {
        const mockResponse = [
          {
            id: 1,
            FirstName: 'Mike',
            LastName: 'Araya',
            Email: 'mike@gmail.com',
            Phone_No: '0920208549',
            Password: '123456',
            Confirm_Password: '123456',
            Gender: 'f',
            Birth_Date: 2018
          }
        ];

        const expectedResult: Users = {
          id: 6,
          FirstName: 'Mike',
          LastName: 'Araya',
          Email: 'mike@gmail.com',
          Phone_No: '0920208549',
          Password: '123456',
          Confirm_Password: '123456',
          Gender: 'f',
          Birth_Date: 2018
        };

        const usersService = getTestBed().get(UsersService);
        usersService.addUser(expectedResult).subscribe(
          actualResult => {
            expect(actualResult.id).toEqual(expectedResult.id);
            expect(actualResult.FirstName).toEqual(expectedResult.FirstName);
            expect(actualResult.LastName).toEqual(expectedResult.LastName);
            expect(actualResult.Email).toEqual(expectedResult.Email);
            expect(actualResult.Phone_No).toEqual(expectedResult.Phone_No);
            expect(actualResult.Password).toEqual(expectedResult.Password);
            expect(actualResult.Confirm_Password).toEqual(expectedResult.Confirm_Password);
            expect(actualResult.Gender).toEqual(expectedResult.Gender);
            expect(actualResult.Birth_Date).toEqual(expectedResult.Birth_Date);
          }
        );

        const req = httpMock.expectOne(r => r.url === usersService.apiEndpoint && r.headers.has('Content-Type'));
        expect(req.request.method).toEqual('POST');

        req.flush(mockResponse);
        httpMock.verify();
      }));

    it('should throw with an error message when API returns an error',
      inject([HttpClient, HttpTestingController], (http: HttpClient, httpMock: HttpTestingController) => {
        const expectedResult: Users = {
          id: 6,
          FirstName: 'Mike',
          LastName: 'Araya',
          Email: 'mike@gmail.com',
          Phone_No: '0920208549',
          Password: '123456',
          Confirm_Password: '123456',
          Gender: 'f',
          Birth_Date: 2018
        };

        const userService = getTestBed().get(UsersService);
        userService.addUser(expectedResult)
          .subscribe(
            response => fail('should fail with status 500 error'),
            (error: HttpErrorResponse) => {
              expect(error).toBeTruthy();
              expect(error.status).toEqual(500);
            }
          );

        const req = httpMock.expectOne(r => r.url === userService.apiEndpoint && r.headers.has('Content-Type'));
        expect(req.request.method).toEqual('POST');

        req.flush({ errorMessage: 'Error!' }, { status: 500, statusText: 'Server Error' });
        httpMock.verify();
      }));
  });
});
