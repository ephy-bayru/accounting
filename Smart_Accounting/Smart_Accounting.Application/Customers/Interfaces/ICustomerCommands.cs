/*
 * @CreateTime: Oct 9, 2018 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 3:21 PM
 * @Description: Modify Here, Please 
 */
using Smart_Accounting.Application.Customers.Models;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Application.Customers.Interfaces {
    public interface ICustomerCommands {
        Customer Create (Customer newCustomer);
        bool Update (Customer customer, UpdateCustomerModel updateCustomer);
        bool Delete (Customer customer);
    }
}