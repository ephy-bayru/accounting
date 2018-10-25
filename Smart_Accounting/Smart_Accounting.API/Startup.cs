﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Smart_Accounting.Application.AccountCharts.Command;
using Smart_Accounting.Application.AccountCharts.Interfaces;
using Smart_Accounting.Application.AccountCharts.Queries;
using Smart_Accounting.Application.CalendarPeriods.Commands;
using Smart_Accounting.Application.CalendarPeriods.Factorys;
using Smart_Accounting.Application.CalendarPeriods.Interfaces;
using Smart_Accounting.Application.CalendarPeriods.Queries;
using Smart_Accounting.Application.Customers.Commands;
using Smart_Accounting.Application.Customers.Interfaces;
using Smart_Accounting.Application.Customers.Queries;
using Smart_Accounting.Application.Customers.Commands.Factories;
using Smart_Accounting.Application.Customers.Factories;
using Smart_Accounting.Application.Employee.Commands;
using Smart_Accounting.Application.Employee.Commands.Factories;
using Smart_Accounting.Application.Employee.Interfaces;
using Smart_Accounting.Application.Employee.Queries;
using Smart_Accounting.Application.Interfaces;
using Smart_Accounting.Application.Organizations.Commands;
using Smart_Accounting.Application.Organizations.Factory;
using Smart_Accounting.Application.Organizations.Interfaces;
using Smart_Accounting.Application.Organizations.Queries;
using Smart_Accounting.Application.Supplier.Commands;
using Smart_Accounting.Application.Supplier.Interfaces;
using Smart_Accounting.Application.Supplier.Queries;
using Smart_Accounting.API.Commons.Factories;
using Smart_Accounting.Persistance;
using Smart_Accounting.Application.Employee.Factories;
using Smart_Accounting.Application.AccountCharts.Factories;
using Smart_Accounting.Application.Supplier.Commands.Factories;
using Smart_Accounting.Application.Supplier.Factories;
using Smart_Accounting.Application.Ledgers.Commands;
using Smart_Accounting.Application.Ledgers.Interfaces;
using Smart_Accounting.Application.Ledgers.Queries;
using Smart_Accounting.Application.Ledgers.Factories;
using Smart_Accounting.Application.Currencies.Commands;
using Smart_Accounting.Application.Currencies.Commands.Factories;
using Smart_Accounting.Application.Currencies.Factories;
using Smart_Accounting.Application.Currencies.Interfaces;
using Smart_Accounting.Application.Currencies.Models;
using Smart_Accounting.Application.Currencies.Queries;
using Smart_Accounting.Application.ExchnageRate.Commands;
using Smart_Accounting.Application.ExchnageRate.Factories;
using Smart_Accounting.Application.ExchnageRate.Interfaces;
using Smart_Accounting.Application.ExchnageRate.Models;
using Smart_Accounting.Application.ExchnageRate.Queries;
using Smart_Accounting.Application.ExchnageRate.Commands.Factories;

namespace Smart_Accounting.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddScoped<IAccountingDatabaseService, AccountingDatabaseService> ();

            services.AddScoped<IAccountChartCommands, AccountChartCommands> ();
            services.AddScoped<IAccountChartFactory, AccountChartFactory> ();
            services.AddScoped<IAccountChartQueries, AccountChartQuery> ();
            services.AddScoped<IOrganizationsQuery, OrganizationQuery> ();
            services.AddScoped<IOrganizationCommands, OrganizationCommand> ();
            services.AddScoped<IOrganizationFactory, OrganizationFactory> ();
            services.AddScoped<ICalendarPeriodQueries, CalendarPeriodsQuery> ();
            services.AddScoped<ICalendarPeriodsCommands, CalendarPeriodsCommands> ();
            services.AddScoped<ICalendarPeriodsCommandsFactory, CalendarPeriodCommandsFactorys> ();

            services.AddScoped<IResponseFactory, ResponseFactory> ();
            services.AddScoped<IEmployeeCommands, EmployeeCommand> ();
            services.AddScoped<IEmployeesQueries, EmployeesQuery> ();
            services.AddScoped<IEmployeeCommandsFactory, EmployeeCommandsFactory> ();
            services.AddScoped<IEmployeeFactory, EmployeeFactory> ();
            services.AddScoped<ICustomerCommands, CustomerCommand> ();
            services.AddScoped<ICustomerCommandsFactory, CustomerCommandsFactory>();
            services.AddScoped<ICustomerQuery, CustomerQuery> ();
            services.AddScoped<ICustomerFactory, CustomerFactory> ();
            services.AddScoped<ISupplierCommandes, SupplierCommand> ();
            services.AddScoped<ISuppliersQuery, SuppliersQuery> ();
            services.AddScoped<ISupplierCommandsFactory, SupplierCommandsFactory>();
            services.AddScoped<ISuppliersFactory, SupplierFactory>();
            services.AddScoped<ILedgersCommand, LedgersCommand>();
            services.AddScoped<ILedgersQuery, LedgersQuery>();
            services.AddScoped<ILedgersFactory, LedgerFactories>();
            services.AddScoped<ICurrencyCommands, CurrencyCommand>();
            services.AddScoped<ICurrencyFactory, CurrunciesFactory>();
            services.AddScoped<ICurrencyQueries, CurrenciesQuery>();
            services.AddScoped<ICurrenciesCommandsFactory, CurrencyCommandsFactory>();
            services.AddScoped<IExRateCommands, ExRateCommand>();
            services.AddScoped<IExRateFactory, ExRateFactory>();
            services.AddScoped<IExRateQueries, ExRateQuery>();
            services.AddScoped<IExRateCommandsFactory, ExRateCommandsFactory>();
            

            services.AddCors (options => {
                options.AddPolicy ("AllowSpecificOrigin",
                    builder1 => builder1.AllowAnyOrigin ().AllowAnyHeader ().AllowAnyMethod ());
            });
            services.AddMvc ()
                .AddJsonOptions (options => options.SerializerSettings.ContractResolver = new DefaultContractResolver ());;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseCors ("AllowSpecificOrigin");
            app.UseMvc ();
        }
    }
}