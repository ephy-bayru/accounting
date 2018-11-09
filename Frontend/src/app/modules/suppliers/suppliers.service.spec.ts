import { TestBed, async, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpEvent, HttpEventType } from '@angular/common/http';
import { SuppliersService } from './suppliers.service';
import { Suppliers } from './suppliers';


describe(`SuppliersService`, () => {
    beforeEach(() => {
      // set up the test environment
      TestBed.configureTestingModule({
        imports: [HttpClientTestingModule],
        providers: [SuppliersService]
      });
    });
    it(
        'should get users',
        inject(
          [HttpTestingController, SuppliersService],
          (
            httpMock: HttpTestingController,
            supplierService: SuppliersService
          ) => {
            //  test logic
const mockSupp = [
    {
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
    },
    {
        id: 2,
        FullName: 'Toshiba',
        Email: 'toshiba@gmail.com',
        PhoneNo: '0921204589',
        Country: 'Ethiopia',
        City: 'Adis',
        SubCity: 'Piasa',
        HouseNo: '2018',
        PostalCode: '1234',
        Balance: 1000,
        Active: 'true',
    },
    {
        id: 3,
        FullName: 'Apple',
        Email: 'apple@gmail.com',
        PhoneNo: '0921204589',
        Country: 'Ethiopia',
        City: 'Adis',
        SubCity: 'Piasa',
        HouseNo: '2018',
        PostalCode: '1234',
        Balance: 1000,
        Active: 'true',
    },
    {
        id: 4,
        FullName: 'Dell',
        Email: 'supp@gmail.com',
        PhoneNo: '0921204589',
        Country: 'Ethiopia',
        City: 'Adis',
        SubCity: 'Piasa',
        HouseNo: '2018',
        PostalCode: '1234',
        Balance: 1000,
        Active: 'true',
    }
];

// supplierService.getSupplier(1).subscribe((event: HttpEvent<any>) => {
//     switch (event.type) {
//       case HttpEventType.Response:
//         expect(event.body).toEqual(Supp);
//     }
//   });
// const mockReq  = httpMock.expectOne(supplierService.Url);
// expect(mockReq.cancelled).toBeFalsy();
//         expect(mockReq.request.responseType).toEqual('json');
//         mockReq.flush(Supp);

//         httpMock.verify();
//           }
//         )
//       );
//     });


describe('SuppliersService', () => {

  let service;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [SuppliersService]
    });
    httpTestingController = TestBed.get(HttpTestingController);
  });

  beforeEach(inject([SuppliersService], s => {
    service = s;
  }));

  beforeEach(() => {
    this.mockSuppliers = [...mockSupp];
    this.mockSupplier = this.mockSupplier[0];
    this.mockId = this.mockSupplier.id;
  });

  const apiUrl = (id: number) => {
    return `${service.Url}/${this.mockId}`;
  };

  afterEach(() => {
    // After every test, assert that there are no more pending requests.
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('getSuppliers', () => {

    it('should return mock Suppliers', () => {
      service.getSuppliers().subscribe(
        suppliers => expect(suppliers.length).toEqual(this.mockSuppliers.length),
        fail
      );
      // Receive GET request
      const req = httpTestingController.expectOne(service.SuppliersUrl);
      expect(req.request.method).toEqual('GET');
      // Respond with the mock suppliers
      req.flush(this.mockSuppliers);
    });
  });

  describe('updateSupplier', () => {

    it('should update supplier', () => {
      service.updateSupplier(this.mockSupplier).subscribe(
        response => expect(response).toEqual(this.mockSupp),
        fail
      );
      // Receive PUT request
      const req = httpTestingController.expectOne(service.suppliersUrl);
      expect(req.request.method).toEqual('PUT');
      // Respond with the updated supplier
      req.flush(this.mockSupplier);
    });
  });

  describe('deleteSupplier', () => {

    it('should delete supplier using id', () => {
      const mockUrl = apiUrl(this.mockId);
      service.deleteSupplier(this.mockId).subscribe(
        response => expect(response).toEqual(this.mockId),
        fail
      );
      // Receive DELETE request
      const req = httpTestingController.expectOne(mockUrl);
      expect(req.request.method).toEqual('DELETE');
      // Respond with the updated supplier
      req.flush(this.mockId);
    });

    it('should delete supplier using Supplier object', () => {
      const mockUrl = apiUrl(this.mockSuppliers.id);
      service.deleteSupplier(this.mockSupplier).subscribe(
        response => expect(response).toEqual(this.mockSupplier.id),
        fail
      );
      // Receive DELETE request
      const req = httpTestingController.expectOne(mockUrl);
      expect(req.request.method).toEqual('DELETE');
      // Respond with the updated supplier
      req.flush(this.mockSupplier.id);
    });
  });
});

