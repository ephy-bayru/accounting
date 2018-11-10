import { SuppliersService } from './suppliers.service';
import { Suppliers, SupplierAccount } from './suppliers';
import { of } from 'rxjs';

describe('CustomerssService', () => {

    let supplierservice: SuppliersService;
    let httpClientSpy: { get: jasmine.Spy, post: jasmine.Spy, put: jasmine.Spy, delete: jasmine.Spy };

    beforeEach(() => {
        httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post', 'put', 'delete']);
        supplierservice = new SuppliersService(<any>httpClientSpy);
    });

    describe('GET supplier', () => {
        it('should return customer', () => {
          const splr = {
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
              BankAccounts: SupplierAccount[''] = [],
            };

            httpClientSpy.get.and.returnValue(of(splr));
            supplierservice.getSupplier(1).subscribe(
                customers => expect(customers).toEqual(splr, 'supplier'),
                fail
            );
            expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
        });

    });

    describe('GET  All Suppliers', () => {
        it('should return all suppliers', () => {
            const suppliers: Suppliers[] =
                [
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
                      Active: 1,
                      BankAccounts: SupplierAccount[''] = [],
                    },
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
                      Active: 1,
                      BankAccounts: SupplierAccount[''] = [],
                    }
                ];
            httpClientSpy.get.and.returnValue(of(Suppliers));
            supplierservice.getSuppliers().subscribe(
                supplier => expect(suppliers).toEqual(supplier, 'suppliers'),
                fail
            );
            expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
            expect(suppliers.length).toBe(2);
        });

    });

    describe('POST Supplier', () => {
        it('should add a supplier', () => {
            httpClientSpy.post.and.returnValue(of(Suppliers));
            const newSupplier = {
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
              Active: 1,
              BankAccounts: SupplierAccount[''] = [],
            };
            supplierservice.addSupplier(newSupplier).subscribe(
                response => expect(response).toEqual(Suppliers),
                fail
            );
        });
    });

    describe('PUT supplier', () => {
        it('should update a supplier', () => {
            httpClientSpy.put.and.returnValue(of(Suppliers));
            const updateSupplier = {
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
              Active: 1,
              BankAccounts: SupplierAccount[''] = [],
            };
            supplierservice.updateSupplier(updateSupplier, 1).subscribe(
                response => expect(response).toEqual(Suppliers),
                fail
            );
        });
    });
    describe('DELETE supplier', () => {
        it('should delete supplier', () => {
            httpClientSpy.delete.and.returnValue(of(true));
            supplierservice.deleteSupplier(1).subscribe(
            );
        });

    });

});


