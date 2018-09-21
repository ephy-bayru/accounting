using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.CalendarPeriods.Models
{
    public class UpdatedCalanderDto: CalanderPeriodDto
    {
        [Required]
        public uint id {get; set;}
        
    }
}