namespace Smart_Accounting.Application.AccountCharts.Models
{
    public class NewAccountModel: AccountChartDto
    {
        public uint periodId {get; set;}
        public double OpeningBalance {get; set;}

    }
}