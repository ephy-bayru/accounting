/*
 * @CreateTime: Sep 14, 2018 4:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 14, 2018 4:36 PM
 * @Description: CalanderPeriod API Controller Test
 */
using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.API.Controllers.Calendarss;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.API.NUnitTest.CalanderPeriod {

    [TestFixture]
    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    public class CalanderPeriodControllerTEST {

        Mock<ICalendarPeriodsCommands> MockCommands;
        Mock<ICalendarPeriodQueries> MockQueries;
        Mock<IResponseFactory> MockResponse;
        Mock<ICalendarPeriodsCommandsFactory> MockFactory;
        Mock<ILogger<CalendarsController>> MockLogger;
        IList<CalendarPeriod> calanderPeriod;
        CalendarPeriod newCalanderPeriod;

        CalendarViewModel calendarView;

        IList<NewCalendarPeriodDto> newCalanderDto;
        UpdatedCalanderDto updatedCalanderDto;

        /// <summary>
        /// Set up the basic workbench for testing calanderperiod controller
        /// </summary>
        [SetUp]
        public void Init () {

            calendarView = new CalendarViewModel () {
                Id = 1,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays (30),
                Active = false

            };

            calanderPeriod = new List<CalendarPeriod> ();

            calanderPeriod.Add (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            });

            newCalanderDto = new List<NewCalendarPeriodDto> ();
            newCalanderDto.Add (new NewCalendarPeriodDto () {
                Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),

            });

            updatedCalanderDto = new UpdatedCalanderDto () {
                id = 1,
                Start = DateTime.Now.AddDays (30),
                End = DateTime.Now.AddDays (60),
                active = 1,
                isBegining = 0
            };

            MockFactory = new Mock<ICalendarPeriodsCommandsFactory> ();
            MockCommands = new Mock<ICalendarPeriodsCommands> ();
            MockQueries = new Mock<ICalendarPeriodQueries> ();
            MockLogger = new Mock<ILogger<CalendarsController>> ();
            MockResponse = new Mock<IResponseFactory> ();

            MockCommands.Setup (command => command.CreateCalendar (calanderPeriod)).Returns (new List<CalendarViewModel> () {
                new CalendarViewModel () {
                        Id = 1,
                            Start = DateTime.Now,
                            End = DateTime.Now.AddDays (30),
                            Active = false
                    },
                    new CalendarViewModel () {
                        Id = 1,
                            Start = DateTime.Now,
                            End = DateTime.Now.AddDays (30),
                            Active = false
                    }
            });

            MockFactory.Setup (factory => factory.NewCalendar (newCalanderDto)).Returns (calanderPeriod);
            MockFactory.Setup (factory => factory.UpdateCalander (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            }, updatedCalanderDto)).Returns (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            });
            MockQueries.Setup (query => query.GetById ((uint) 1)).Returns (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            });

        }

        /// <summary>
        /// Test For Asserting if a correct calander period dto is passed to controller result in successfull
        /// creation of calander period
        /// </summary>
        [Test]
        public void CreateCalanderPeriodPOST_Valid_calander_TEST () {

            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod (newCalanderDto);

            result.StatusCode.Should ().Be (201);
            result.Value.GetType ().Should ().Be (typeof (List<CalendarViewModel>));

        }

        /// <summary>
        /// Test if a calander start date the overlap with existing calander setting results in 
        /// unprocessable 422 error
        /// </summary>
        [Test]
        public void CreateCalanderPeriodPOST_DateStart_OverLap_TEST () {
            MockQueries.Setup (query => query.IsStartDateOveraped (newCalanderDto[0].Start)).Returns (true);
            MockQueries.Setup (query => query.IsEndDateOveraped (newCalanderDto[0].End)).Returns (false);

            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod (newCalanderDto);

            result.StatusCode.Should ().Be (422);
        }

        /// <summary>
        /// Test if a calander End date the overlap with existing calander setting results in 
        /// unprocessable 422 error
        /// </summary>
        [Test]
        public void CreateCalanderPeriodPOST_DateEnd_OverLap_TEST () {
            MockQueries.Setup (query => query.IsStartDateOveraped (newCalanderDto[0].Start)).Returns (true);
            MockQueries.Setup (query => query.IsEndDateOveraped (newCalanderDto[0].End)).Returns (false);

            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod (newCalanderDto);

            result.StatusCode.Should ().Be (422);
        }

        /// <summary>
        /// Test if valid calander value passed to updateCalandeer controller results with a status code 0f 204 No Content
        /// </summary>
        [Test]
        public void UpdateCalanderPeriodPUT_ValidDTO_TEST () {
            MockCommands.Setup (command => command.UpdateCalendar (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 1,
                    IsBegining = 0
            })).Returns (true);
            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);
            uint id = 1;

            var result = (ObjectResult) calanderController.UpdateCalendarPeriod (id, updatedCalanderDto);

            result.StatusCode.Should ().Be (500);
        }

        /// <summary>
        /// Test if any database related error while updating calander results in 500 database error
        /// </summary>
        [Test]
        public void UpdateCalanderPeriodPUT_Database_Error_TEST () {
            MockCommands.Setup (command => command.UpdateCalendar (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            })).Returns (false);
            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);
            uint id = 1;

            var result = (ObjectResult) calanderController.UpdateCalendarPeriod (id, updatedCalanderDto);

            result.StatusCode.Should ().Be (500);
        }

        /// <summary>
        /// Test Successful deletin of a calander period definition passed the with existing calander period definition 
        /// ID
        /// </summary>
        [Test]
        public void DeleteCalanderPeriodDELET_Successfull_TEST () {
            MockCommands.Setup (command => command.DeleteCalendar (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            })).Returns (true);
            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);
            uint id = 1;

            var result = (ObjectResult) calanderController.DeleteCalendarPeriod (id);

            result.StatusCode.Should ().Be (500);

        }

        /// <summary>
        /// Test The Return of 404 not found status code when passed non existing  calander period definition ID
        ///
        /// </summary>
        [Test]
        public void DeleteCalanderPeriodDELET_NotFound_TEST () {
            MockCommands.Setup (command => command.DeleteCalendar (new CalendarPeriod () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            })).Returns (true);
            CalendarsController calanderController = new CalendarsController (
                MockQueries.Object,
                MockCommands.Object,
                MockFactory.Object,
                MockResponse.Object,
                MockLogger.Object);
            uint id = 10;

            var result = (StatusCodeResult) calanderController.DeleteCalendarPeriod (id);

            result.StatusCode.Should ().Be (404);

        }

    }
}