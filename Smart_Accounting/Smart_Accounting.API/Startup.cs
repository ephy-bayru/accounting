using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Smart_Accounting.Application.AccountCharts.Command;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Queries;
using Smart_Accounting.Application.Customers.Commands;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Queries;
using Smart_Accounting.Application.Employee.Commands;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Queries;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Supplier.Commands;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Queries;
using Smart_Accounting.Persistance;

namespace Smart_Accounting.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountingDatabaseService, AccountingDatabaseService>();
            services.AddMvc();
         
            services.AddScoped<IAccountChartCommands, AccountChartCommands>();
            services.AddScoped<IEmployeeCommands, EmployeeCommand>();
            services.AddScoped<IEmployeesQueries,  EmployeesQuery>();
            services.AddScoped<IEmployeeCommandsFactory,  EmployeeCommandsFactory>();
            services.AddScoped<IAccountChartQueries, AccountChartQuery>();
            services.AddScoped<ISupplierCommandes, SupplierCommandes>();
            services.AddScoped<ISuppliersQuery, SuppliersQuery>();
            services.AddScoped<ICustomerCommands, CustomerCommand>();
            services.AddScoped<ICustomerQuery, CustomerQuery>();
    
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
