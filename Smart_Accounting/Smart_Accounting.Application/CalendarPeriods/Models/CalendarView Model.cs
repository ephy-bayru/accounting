/*
 * @CreateTime: Nov 10, 2018 9:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 9:58 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace Smart_Accounting.Application.CalendarPeriods.Models
{
    public class CalendarViewModel
    {

        public uint Id;
        public DateTime Start;
        public DateTime End;
        public bool Active ;
        public bool IsBegining;
        public DateTime? DateAdded {get; set;}
        public DateTime? DateUpdate {get; set;}
    }
}