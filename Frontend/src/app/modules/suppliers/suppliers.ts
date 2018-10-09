export class Suppliers {
    id: number;
    FullName: string;
    Email: string;
    Phone_No: string;
    Country: string;
    City: string;
    SubCity: string;
    HouseNo: string;
    PostalCode: string;
    Date_Created: Date;
    Date_Updated: Date;
    BankAccounts: SupplierAccount[] = [];
}
export class SupplierAccount {
    AccountNumber: string;
    BankName: string;
}
