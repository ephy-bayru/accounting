
using System;
using Microsoft.EntityFrameworkCore;
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


        public CalendarViewModel CreateCalendar(NewCalendarModel newCalendar)
        { 
            try{
             var calendar = _calendarCommandFactory.NewCalendar(newCalendar);
            _database.CalendarPeriod.Add(calendar);
            _database.Save();

            return _calendarCommandFactory.CalendarView(calendar);
            }catch (Exception) {
                return  null;
            }
        }

        public bool DeleteCalendar(CalendarPeriod calender)
        {
            try {
                _database.CalendarPeriod.Remove (calender);
                _database.Save (); // save change in the database
                return true;
            } catch (Exception) {
                return false;
            }

        }

        public bool UpdateCalendar(CalendarPeriod calender, UpdateCalendarModel UpdateCalendar)
        {
             try {
                var calendar = _calendarCommandFactory.UpdateCalander (calender, UpdateCalendar);
                _database.CalendarPeriod.Add (calendar).State = EntityState.Modified;
                _database.Save ();
                return true;
            } catch (Exception) {
                return false;
            }
        }


        /* 
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
}*/
    }
}