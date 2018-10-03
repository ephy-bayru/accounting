using System.Collections.Generic;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Interfaces
{
    public interface ICustomerQuery
    {
        Customer GetById(uint id);
         IEnumerable<Customer> GetAll();
    }
}