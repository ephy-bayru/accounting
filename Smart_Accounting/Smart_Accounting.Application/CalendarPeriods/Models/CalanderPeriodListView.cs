/*
 * @CreateTime: Oct 11, 2018 3:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 9, 2018 5:04 PM
 * @Description: Modify Here, Please 
 */
namespace Smart_Accounting.Application.CalendarPeriods.Models
{
    public class CalanderPeriodListView
    {
     public uint Id {get; set;}
     public string Period {get; set;}   
     public string Status {get; set;}
     public sbyte? IsBegining {get; set;}
     public bool IsClosed {get; set;}
    }
}