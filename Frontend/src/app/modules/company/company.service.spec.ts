/*
 * @CreateTime: Sep 7, 2018 11:38 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2018 11:43 AM
 * @Description: Company Service Testing Module
 */

import { CompanyService, Organization } from './company.service';
import { of } from 'rxjs';

describe('CompanyService', () => {

  let companyService: CompanyService;
  let httpClient;
  let company: Organization;
  let companies: Organization[];
  let returnedCompanies: Organization[];
  let returned: Organization;

  beforeEach(() => {
    httpClient = jasmine.createSpyObj(['get', 'post', 'put', 'delete']);
    companyService = new CompanyService(httpClient);

    company = new Organization();
    company.id = 1;
    company.Location = 'AA';
    company.Name = 'AppDiv';
    company.Tin = '1234567890';

  });

  // Tests CompanyService GetCompanyById Function
  describe('GetCompanyById', () => {
    it('Should Return single Company', () => {
      httpClient.get.and.returnValue(of(company));
      companyService.getOrganizationById(1).subscribe(
        com => returned = com
      );
      expect(returned).toBe(company);
    });
  });
    // tests Company Service GetAllCompanies Function
    describe('GetAllCompany', () => {

    it('Should Return array of Companies', () => {
      companies = [
        { id: 1, Name: 'AppDiv', Location: 'AA', Tin: '1234567890' },
        { id: 1, Name: 'AppDiv 2', Location: 'AA', Tin: '1234567890' }
      ];
      httpClient.get.and.returnValue(of(companies));
      companyService.getOrganizationsList().subscribe(
        comps => returnedCompanies = comps);

        expect(returnedCompanies.length).toBe(2);
    });

  });

  // Test CompanyService Create Company Function
    describe('CreateCompany', () => {
        it('Should Return A Single Company', () => {
          httpClient.post.and.returnValue(of(company));
          const newComp = {Name: 'AppDiv', Location: 'AA', Tin: '1234567890'};
          companyService.createOrganization(newComp).subscribe(
            comp => returned = comp
          );

          expect(returned).toBe(company);

        });
    });


    // test Company service Update  Function
    describe('UpdateCompany', () => {
        it('Should Return True on Success', () => {
          httpClient.put.and.returnValue(of(true));
          let updated = false;
          const updatedComp = {Name: 'AppDiv', Location: 'AA', Tin: '1234567890'};
          companyService.updateOrganization(1, updatedComp).subscribe(
            res => updated = res
          );

          expect(updated).toBe(true);
        });
    });

    // Test CompanyService DeleteCompany Function
    describe('DeleteCompany', () => {
      it('Should Return True on Success', () => {
        httpClient.delete.and.returnValue(of(true));
        let deleted = false;
        companyService.deleteOrganization(1).subscribe(
          res => deleted = res
        );

        expect(deleted).toBe(true);
      });
    });





  });


