using Smart_Accounting.Application.AccountCharts.Models;

namespace Smart_Accounting.Application.AccountCharts.Interfaces {
    public interface IAccountChartCommands {
        void create ();
        void creatAccountType (NewAccountTypeModel newType);
        void delete ();
    }
}