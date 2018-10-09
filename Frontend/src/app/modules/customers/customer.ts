export class Customer {
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
    BankAccounts: CustomerAccount[] = [];
}

export class CustomerAccount {
    AccountNumber: string;
    BankName: string;
}
