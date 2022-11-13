﻿using Microsoft.Extensions.DependencyInjection;
using SalaryService.Application.Commands;
using SalaryService.Application.Queries;
using SalaryService.Application.Services;
using SalaryService.Application.Services.HelpServices;

namespace SalaryService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddTransient<GetEmployeeByIdQueryHandler>();
            services.AddTransient<GetBasicSalaryParametersQueryHandler>();
            services.AddTransient<CreateEmployeeCommandHandler>();
            services.AddTransient<UpdateEmployeeCommandHandler>();
            services.AddTransient<CreateBasicSalaryParametersCommandHandler>();
            services.AddTransient<UpdateBasicSalaryParametersCommandHandler>();
            services.AddTransient<UpdateFinancialMetricsCommandHandler>();
            services.AddTransient<CreateHistoryMetricsCommandHandler>();
            services.AddTransient<EmployeeSalaryService>();
            services.AddTransient<FakeTaxService>();
            return services;
        }
    }
}
