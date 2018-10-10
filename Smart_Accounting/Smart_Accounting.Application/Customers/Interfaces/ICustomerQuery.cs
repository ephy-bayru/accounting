/*
 * @CreateTime: Oct 10, 2018 9:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 9:16 AM
 * @Description: Modify Here, Please 
 */
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