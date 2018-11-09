import { CustomerService } from './customer.service';
import { Customer, CustomerAccount } from './customer';
import { of } from 'rxjs';

describe('CustomerssService', () => {

    let customerservice: CustomerService;
    let httpClientSpy: { get: jasmine.Spy, post: jasmine.Spy, put: jasmine.Spy, delete: jasmine.Spy };

    beforeEach(() => {
        httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post', 'put', 'delete']);
        customerservice = new CustomerService(<any>httpClientSpy);
    });

    describe('GET customer', () => {
        it('should return customer', () => {
            const cstmr: Customer = {
                id: 1,
                FullName: 'Dell',
                Email: 'dell@gmail.com',
                Phone_No: '0921204589',
                Country: 'Ethiopia',
                City: 'Adis',
                SubCity: 'Piasa',
                HouseNo: '2018',
                PostalCode: '1234',
                Balance: 1000,
                CreditLimit: 10000,
                Active: 1,
                BankAccounts: CustomerAccount[''] = [],
            };

            httpClientSpy.get.and.returnValue(of(cstmr));
            customerservice.getCustomer(1).subscribe(
                customers => expect(customers).toEqual(cstmr, 'customer'),
                fail
            );
            expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
        });

    });

    describe('GET  All Customers', () => {
        it('should return all customers', () => {
            const Customers: Customer[] =
                [
                    {
                        id: 1,
                        FullName: 'Dell',
                        Email: 'dell@gmail.com',
                        Phone_No: '0921204589',
                        Country: 'Ethiopia',
                        City: 'Adis',
                        SubCity: 'Piasa',
                        HouseNo: '2018',
                        PostalCode: '1234',
                        Balance: 1000,
                        CreditLimit: 10000,
                        Active: 1,
                        BankAccounts: CustomerAccount[''] = [],
                    },
                    {
                        id: 2,
                        FullName: 'Toshiba',
                        Email: 'Toshiba@gmail.com',
                        Phone_No: '0921204589',
                        Country: 'Koria',
                        City: 'Adis',
                        SubCity: 'Piasa',
                        HouseNo: '2018',
                        PostalCode: '1234',
                        Balance: 1000,
                        CreditLimit: 10000,
                        Active: 1,
                        BankAccounts: CustomerAccount[''] = [],
                    }
                ];
            httpClientSpy.get.and.returnValue(of(Customers));
            customerservice.getCustomers().subscribe(
                customers => expect(customers).toEqual(Customers, 'customers'),
                fail
            );
            expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
            expect(Customers.length).toBe(2);
        });

        // it('should return an error when the server returns a 404', () => {
        //     const errorResponse = new HttpErrorResponse({
        //       error: 'test 404 error',
        //       status: 404, statusText: 'Not Found'
        //     });
        //     httpClientSpy.get.and.returnValue(of(errorResponse));
        //     customerservice.getCustomer(1).subscribe(
        //       customer => fail('expected an error, not customer'),
        //       error  => expect(error.message).toContain('test 404 error')
        //     );
        //   });

    });

    describe('POST Customer', () => {
        it('should add a customer', () => {
            httpClientSpy.post.and.returnValue(of(Customer));
            const newCustomer = {
                id: 1,
                FullName: 'Dell',
                Email: 'dell@gmail.com',
                Phone_No: '0921204589',
                Country: 'Ethiopia',
                City: 'Adis',
                SubCity: 'Piasa',
                HouseNo: '2018',
                PostalCode: '1234',
                Balance: 1000,
                CreditLimit: 10000,
                Active: 1,
                BankAccounts: CustomerAccount[''] = []
            };
            customerservice.addCustomer(newCustomer).subscribe(
                response => expect(response).toEqual(Customer),
                fail
            );
        });
    });

    describe('PUT Customer', () => {
        it('should update a customer', () => {
            httpClientSpy.put.and.returnValue(of(Customer));
            const updateCustomer = {
                id: 1,
                FullName: 'toshiba',
                Email: 'toshiba@gmail.com',
                Phone_No: '0921204589',
                Country: 'koria',
                City: 'soul',
                SubCity: 'Piasa',
                HouseNo: '2018',
                PostalCode: '1234',
                Balance: 1000,
                CreditLimit: 10000,
                Active: 1,
                BankAccounts: CustomerAccount[''] = []
            };
            customerservice.updateCustomer(updateCustomer, 1).subscribe(
                response => expect(response).toEqual(Customer),
                fail
            );
        });
    });
    describe('DELETE customer', () => {
        it('should delete customer', () => {

            httpClientSpy.delete.and.returnValue(of(true));
            customerservice.deleteCustomer(1).subscribe(
            );
        });

    });

});
