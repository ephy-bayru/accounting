using System;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Domain.Employe
{
    public class Employees
    {
          public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateCreated { get; set; }
        public uint? AccountId { get; set; }
        public DateTime DateUpdated { get; set; }

        public AccountChart Account { get; set; }
    }
}
