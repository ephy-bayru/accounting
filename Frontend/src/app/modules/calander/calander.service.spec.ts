
import { CalanderService, CalanderPeriod } from './calander.service';
import { of } from 'rxjs';

describe('CalanderService', () => {

  let calanderService: CalanderService;
  let httpClient;
  let calander: CalanderPeriod;
  let calanderPeriods: CalanderPeriod[];
  let returnedCalanderPeriod: CalanderPeriod[];
  let returned: CalanderPeriod;

  beforeEach(() => {
    httpClient = jasmine.createSpyObj(['get', 'post', 'put', 'delete']);
    calanderService = new CalanderService(httpClient);

    calander = new CalanderPeriod();
    calander.id = 1;
    calander.startDate = '2018-08-10';
    calander.endDate = '2018-09-11';
    calander.active = false;

  });

  // Tests CalanderService GetCalanderPeriodById Function
  describe('GetCalanderPeriodById', () => {
    it('Should Return single Calander Periods', () => {
      httpClient.get.and.returnValue(of(calander));
      calanderService.getCalanderById(1).subscribe(
        com => returned = com
      );
      expect(returned).toBe(calander);
    });
  });
  // tests Calander Service GetCalanderPeriodsList Function
  describe('GetAllCalanderPeriod', () => {

    it('Should Return array of Calander Periods', () => {
      calanderPeriods = [{ id: 1,  startDate: '2018-09-10', endDate: '2018-11-10', active: false
    },
      {  id: 2,  startDate: '2018-09-10', endDate: '2018-11-10', active: true }
      ];
    httpClient.get.and.returnValue(of(calanderPeriods));
    calanderService.getCalanderPeriodsList().subscribe(
      cals => returnedCalanderPeriod = cals);

    expect(returnedCalanderPeriod.length).toBe(2);
  });

});

// Test CalanderService Create Calander Function
describe('CreateCalanderPeriod', () => {
  it('Should Return A Single Company', () => {
    httpClient.post.and.returnValue(of(calander));
    const newCal = { startDate: '2018-11-11',  endDate: '2018-12-11', active: false };
    calanderService.createCalanderPeriod(newCal).subscribe(
      cals => returned = cals
    );

    expect(returned).toBe(calander);

  });
});


// test CalanderService UpdateCalanderPeriod  Function
describe('UpdateCalanderPeriod', () => {
  it('Should Return True on Success', () => {
    httpClient.put.and.returnValue(of(true));
    let updated = false;
    const updatedComp = { id: 1,  startDate: '2018-11-11',  endDate: '2018-12-11', active: false  };
    calanderService.updateCalanderPeriod(1, updatedComp).subscribe(
      response => updated = response
    );

    expect(updated).toBe(true);
  });
});

// Test CalanderService DeleteCalanderPeriod Function
describe('DeleteCalanderPeriod', () => {
  it('Should Return True on Success', () => {
    httpClient.delete.and.returnValue(of(true));
    let deleted = false;
    calanderService.deleteCalanderPeriod(1).subscribe(
      response => deleted = response
    );

    expect(deleted).toBe(true);
  });
});





  });
