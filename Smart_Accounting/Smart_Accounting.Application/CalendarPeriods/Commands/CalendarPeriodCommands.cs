
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.Domain.CalendarPeriods;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;

namespace Smart_Accounting.Application.CalendarPeriods.Commands
{
    public class CalendarPeriodsCommands : ICalendarPeriodsCommands 
    {
        private readonly IAccountingDatabaseService _database;
        private readonly ICalendarPeriodsCommandsFactory _calendarCommandFactory;

        public CalendarPeriodsCommands(IAccountingDatabaseService database,
                                        ICalendarPeriodsCommandsFactory calendarCommandFactory)
                                        {
                                             _database = database;
                                             _calendarCommandFactory=calendarCommandFactory;
                                        }
        public void Create (NewCalendarModel newCalendar)   
        {
             var calendar = _calendarCommandFactory.NewCalendar(newCalendar);
            _database.CalendarPeriod.Add(calendar);
            _database.Save();
            
        }

        public void Delete(CalendarPeriod calender)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}