/*
 * @CreateTime: Sep 14, 2018 4:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 14, 2018 4:36 PM
 * @Description: CalanderPeriod API Controller Test
 */
using System;
using Moq;
using NUnit.Framework;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Models;
using Smart_Accounting.API.Controllers.Calendarss;
using Smart_Accounting.Domain.CalendarPeriods;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Smart_Accounting.API.NUnitTest.CalanderPeriod {

    [TestFixture]
    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    public class CalanderPeriodControllerTEST {

        Mock<ICalendarPeriodsCommands> MockCommands;
        Mock<ICalendarPeriodQueries> MockQueries;
        Mock<ICalendarPeriodsCommandsFactory> MockFactory;
        CalendarPeriod calanderPeriod;
        CalanderPeriodDto updatedCalanderDto;
        CalendarPeriod newCalanderPeriod;

        CalendarViewModel calendarView;

        CalanderPeriodDto calanderDto;


        /// <summary>
        /// Set up the basic workbench for testing calanderperiod controller
        /// </summary>
        [SetUp]
        public void Init () {

            calendarView = new CalendarViewModel () {
                Id = 1,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays (30),
                Active = 0

            };

            calanderPeriod = new CalendarPeriod () {
                Id = 1,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays (30),
                Active = 0
            };

            calanderDto = new CalanderPeriodDto () {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays (30),

            };

            updatedCalanderDto = new CalanderPeriodDto () {
                id = 1,
                Start = DateTime.Now.AddDays(30),
                End = DateTime.Now.AddDays (60)
            };

            MockFactory = new Mock<ICalendarPeriodsCommandsFactory> ();
            MockCommands = new Mock<ICalendarPeriodsCommands> ();
            MockQueries = new Mock<ICalendarPeriodQueries> ();

            MockCommands.Setup (command => command.CreateCalendar (calanderPeriod)).Returns (new CalendarViewModel () {
                Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays (30),
                    Active = 0
            });
            

            MockFactory.Setup (factory => factory.NewCalendar (calanderDto)).Returns (calanderPeriod);
            MockFactory.Setup (factory => factory.UpdateCalander (calanderDto)).Returns (calanderPeriod);
            MockQueries.Setup(query => query.GetById((uint) 1)).Returns(calanderPeriod);

        }

        /// <summary>
        /// Test For Asserting if a correct calander period dto is passed to controller result in successfull
        /// creation of calander period
        /// </summary>
        [Test]
        public void CreateCalanderPeriodPOST_Valid_calander_TEST () {

            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod(calanderDto);

            result.StatusCode.Should().Be(201);
            result.Value.GetType().Should().Be(typeof(CalendarViewModel));

        }

        /// <summary>
        /// Test if a missing calander period DTO or invalid DTO results in 500 server error response
        /// </summary>
        [Test]
        public void CreatCalanderPeriodPOST_Invalid_DTO_TEST() {

            CalanderPeriodDto invalid = new CalanderPeriodDto() {
                Start = DateTime.Now
            };

            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod(invalid);

            result.StatusCode.Should().Be(500);


        }


        /// <summary>
        /// Test if a calander start date the overlap with existing calander setting results in 
        /// unprocessable 422 error
        /// </summary>
        [Test]
        public void CreateCalanderPeriodPOST_DateStart_OverLap_TEST() {
            MockQueries.Setup(query => query.IsStartDateOveraped(calanderDto.Start)).Returns(true);
            MockQueries.Setup(query => query.IsEndDateOveraped(calanderDto.End)).Returns(false);

            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod(calanderDto);

            result.StatusCode.Should().Be(422);
        }


        /// <summary>
        /// Test if a calander End date the overlap with existing calander setting results in 
        /// unprocessable 422 error
        /// </summary>
        [Test]
        public void CreateCalanderPeriodPOST_DateEnd_OverLap_TEST() {
            MockQueries.Setup(query => query.IsStartDateOveraped(calanderDto.Start)).Returns(false);
            MockQueries.Setup(query => query.IsEndDateOveraped(calanderDto.End)).Returns(true);

            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);

            var result = (ObjectResult) calanderController.CreateNewCalendarPeriod(calanderDto);

            result.StatusCode.Should().Be(422);
        }


        /// <summary>
        /// Test if valid calander value passed to updateCalandeer controller results with a status code 0f 204 No Content
        /// </summary>
        [Test]
        public void UpdateCalanderPeriodPUT_ValidDTO_TEST() {
            MockCommands.Setup (command => command.UpdateCalendar (calanderPeriod)).Returns (true);
            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);
            uint id =1;

            var result = (StatusCodeResult) calanderController.UpdateCalendarPeriod(id, calanderDto);

            result.StatusCode.Should().Be(204);
        }

        /// <summary>
        /// Test if any database related error while updating calander results in 500 database error
        /// </summary>
        [Test]
        public void UpdateCalanderPeriodPUT_Database_Error_TEST() {
            MockCommands.Setup (command => command.UpdateCalendar (calanderPeriod)).Returns(false);
            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);
            uint id =1;

            var result = (ObjectResult) calanderController.UpdateCalendarPeriod(id, calanderDto);

            result.StatusCode.Should().Be(500);
        }

        /// <summary>
        /// Test Successful deletin of a calander period definition passed the with existing calander period definition 
        /// ID
        /// </summary>
        [Test]
        public void DeleteCalanderPeriodDELET_Successfull_TEST() {
            MockCommands.Setup (command => command.DeleteCalendar (calanderPeriod)).Returns(true);
            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);
            uint id =1;

            var result = (StatusCodeResult) calanderController.DeleteCalendarPeriod(id);

            result.StatusCode.Should().Be(204);

        }

        /// <summary>
        /// Test The Return of 404 not found status code when passed non existing  calander period definition ID
        ///
        /// </summary>
        [Test]
        public void DeleteCalanderPeriodDELET_NotFound_TEST() {
            MockCommands.Setup (command => command.DeleteCalendar (calanderPeriod)).Returns(true);
            CalendarsController calanderController = new CalendarsController (MockQueries.Object, MockCommands.Object, MockFactory.Object);
            uint id =10;

            var result = (StatusCodeResult) calanderController.DeleteCalendarPeriod(id);

            result.StatusCode.Should().Be(404);

        }

    }
}