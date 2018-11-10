export class Suppliers {
    id: number;
    FullName: string;
    Email: string;
    PhoneNo: string;
    Country: string;
    City: string;
    SubCity: string;
    HouseNo: string;
    PostalCode: string;
    Balance: number;
    Active: number;
    BankAccounts: SupplierAccount[] = [];


    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
export class SupplierAccount {
    AccountNumber: string;
    BankName: string;
}
