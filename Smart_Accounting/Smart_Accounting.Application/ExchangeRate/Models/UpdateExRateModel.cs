using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Accounting.Application.ExchnageRate.Models {
    public class UpdateExRateModel : ExRateDto {
        [Required]
        public uint ID { get; set; }
    }
}