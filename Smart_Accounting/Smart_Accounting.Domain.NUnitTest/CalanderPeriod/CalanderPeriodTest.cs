/*
 * @CreateTime: Sep 8, 2018 12:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2018 12:13 PM
 * @Description: Organization Calaner Period Domain Unit Test 
 */
using System;
using NUnit.Framework;
using Smart_Accounting.Domain.CalendarPeriods;

namespace Smart_Accounting.Domain.NUnitTest.CalanderPeriod {

    [Author ("Mikael Araya", "MikaelAraya12@gmail.com")]
    [TestFixture]
    public class CalanderPeriodTest {

        private CalendarPeriod calander;
        
        [SetUp]
        public void Init () {
            calander = new CalendarPeriod() {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
            };
            

        }
        [Test]
        public void CalanderPropertiesInitializationTest() {

            Assert.That(calander.Start.ToString(), Is.EqualTo(DateTime.Now.ToString()));
            Assert.That(calander.End.ToString(), Is.EqualTo(DateTime.Now.AddDays(1).ToString()));
        } 
        
        [Test]
        public void Calander_Satrt_Less_than_End_Test() {
            Assert.That(calander.Start , Is.LessThan(calander.End));
        }

    }
}