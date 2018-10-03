import { TestBed, inject } from '@angular/core/testing';

import { AccountsService } from './accounts.service';
import { Accounts } from './accounts';
import { of } from 'rxjs';

describe('AccountsService', () => {
  let accountsService: AccountsService;
  let httpClient;
  let account: Accounts;
  let accounts: Accounts[];
  let returnedCompanies: Accounts[];
  let returned: Accounts[];
  let result: Accounts;

  beforeEach(() => {
    httpClient = jasmine.createSpyObj(['get', 'post', 'put', 'delete']);
    accountsService = new AccountsService(httpClient);

    account = new Accounts();
    account.AccountCode = '1';
    account.AccountId = '3';
    account.Name = 'first account';
    account.organizationId = 1;
    account.openingBalance = 100;
    account.Active = true;

  });

  // Tests AccountsService GetaccountById Function
  describe('GetaccountById', () => {
    it('Should Return single account', () => {
      httpClient.get.and.returnValue(of(account));
      accountsService.getAccountById('1').subscribe(
        com => result = com
      );
      expect(result).toBe(account);
    });
  });
  // tests account Service GetAllCompanies Function
  describe('GetAllaccount', () => {

    it('Should Return array of Accounts', () => {
      accounts = [{ Name: 'AppDiv', organizationId: 1, AccountCode: '1', AccountId: '3', openingBalance: 100, Active: true },
      { Name: 'AppDiv', organizationId: 1, AccountCode: '1', AccountId: '3', openingBalance: 100, Active: true }
      ];
      httpClient.get.and.returnValue(of(accounts));
      accountsService.getAccountsList().subscribe(
        comps => returnedCompanies = comps);

      expect(returnedCompanies.length).toBe(2);
    });

  });

  // Test AccountsService Create account Function
  describe('Createaccount', () => {
    it('Should Return A Single account', () => {
      httpClient.post.and.returnValue(of(accounts));
      const newComp = [{Name: 'AppDiv', organizationId: 1, AccountCode: '1', AccountId: '3', openingBalance: 100, Active: true }];
      accountsService.createAccount(newComp).subscribe(
        (comp: Accounts[]) => returned = comp
      );

      expect(returned).toBe(accounts);

    });
  });


  // test account service Update  Function
  describe('Updateaccount', () => {
    it('Should Return True on Success', () => {
      httpClient.put.and.returnValue(of(true));
      let updated = false;
      const updatedComp = {Name: 'AppDiv', organizationId: 1, AccountCode: '1', AccountId: '3', openingBalance: 100, Active: true };
      accountsService.updateAccount(1, updatedComp).subscribe(
        res => updated = res
      );

      expect(updated).toBe(true);
    });
  });

  // Test AccountsService Deleteaccount Function
  describe('Deleteaccount', () => {
    it('Should Return True on Success', () => {
      httpClient.delete.and.returnValue(of(true));
      let deleted = false;
      accountsService.deleteAccount(1).subscribe(
        res => deleted = res
      );

      expect(deleted).toBe(true);
    });
  });

});
