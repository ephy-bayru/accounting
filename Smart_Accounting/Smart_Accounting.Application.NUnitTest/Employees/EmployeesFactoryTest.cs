using System;
using NUnit.Framework;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Models;
using Smart_Accounting.Domain.Employe;


namespace Smart_Accounting.Application.NUnitTest.Employees.Factories
{
    [TestFixture]
    public class CustomersFactoryTest
    {

        private UpdatedEmployeeDto updateEmployee;
        private EmployeeCommandsFactory employeesCommandFactory;
        private NewEmployeeModel newEmployeeModel;

        [OneTimeSetUp]

        public void Emp()
        {
            newEmployeeModel = new NewEmployeeModel();
            updateEmployee = new UpdatedEmployeeDto();
            employeesCommandFactory = new EmployeeCommandsFactory();

            newEmployeeModel.First_Name = "ephrem";
            newEmployeeModel.Last_Name = "bayru";
            newEmployeeModel.Account_Id = 123456;
            newEmployeeModel.Phone_No = "0920208549";
            newEmployeeModel.Email = "email";
            newEmployeeModel.Password = "123456";

            // Update customer model
            updateEmployee.id = 2;
            updateEmployee.First_Name = "ephy";
            updateEmployee.Last_Name = "bayru";
            updateEmployee.Account_Id = 123456;
            updateEmployee.Phone_No = "0920208549";
            updateEmployee.Email = "mail";
            updateEmployee.Password = "123456";

        }
        [Test]
        public void NewEmployeeTest()
        {
        }
}
}