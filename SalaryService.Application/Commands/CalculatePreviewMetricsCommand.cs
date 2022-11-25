﻿using Microsoft.EntityFrameworkCore;
using SalaryService.Application.Dtos;
using SalaryService.DataAccess;
using SalaryService.Domain;

namespace SalaryService.Application.Commands
{
    public partial class CalculatePreviewMetricsCommand
    {
    }

    public partial class CalculatePreviewMetricsCommandHandler
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public CalculatePreviewMetricsCommandHandler(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<MetricsPreviewDto> Handle(FinanceUpdatingParameters request, EmployeeFinancialMetrics newMetrics)
        {
            var employee = await _employeeDbContext
                .Set<Employee>()
                .Include(x => x.EmployeeFinanceForPayroll)
                .Include(x => x.EmployeeFinancialMetrics)
                .SingleAsync(x => x.Id == request.EmployeeId && x.DeletedAtUtc == null);

            var preview = CalculateDelta(new MetricsPreviewDto(employee.Id,
                employee.Name + " " + employee.Surname + " " + employee.MiddleName,
                newMetrics.Pay,
                newMetrics.RatePerHour,
                newMetrics.EmploymentType,
                newMetrics.ParkingCostPerMonth,
                newMetrics.HourlyCostFact,
                newMetrics.HourlyCostHand,
                newMetrics.Earnings,
                newMetrics.IncomeTaxContributions,
                newMetrics.PensionContributions,
                newMetrics.MedicalContributions,
                newMetrics.SocialInsuranceContributions,
                newMetrics.InjuriesContributions,
                newMetrics.Expenses,
                newMetrics.Profit,
                newMetrics.ProfitAbility,
                newMetrics.GrossSalary,
                newMetrics.Retainer,
                newMetrics.NetSalary), 
                employee);

            return preview;
        }

        private MetricsPreviewDto CalculateDelta(MetricsPreviewDto preview, Employee employee)
        {
            preview.PayDelta = Math.Round(preview.Pay - employee.EmployeeFinancialMetrics.Pay, 2);
            preview.RatePerHourDelta = Math.Round(preview.RatePerHour - employee.EmployeeFinancialMetrics.RatePerHour, 2);
            preview.HourlyCostFactDelta = Math.Round(preview.HourlyCostFact - employee.EmployeeFinancialMetrics.HourlyCostFact, 2);
            preview.HourlyCostHandDelta = Math.Round(preview.HourlyCostHand - employee.EmployeeFinancialMetrics.HourlyCostHand, 2);
            preview.EarningsDelta = Math.Round(preview.Earnings - employee.EmployeeFinancialMetrics.Earnings, 2);
            preview.IncomeTaxContributionsDelta = Math.Round(preview.IncomeTaxContributions - employee.EmployeeFinancialMetrics.IncomeTaxContributions, 2);
            preview.PensionContributionsDelta = Math.Round(preview.PensionContributions - employee.EmployeeFinancialMetrics.PensionContributions, 2);
            preview.MedicalContributionsDelta = Math.Round(preview.MedicalContributions - employee.EmployeeFinancialMetrics.MedicalContributions, 2);
            preview.InjuriesContributionsDelta = Math.Round(preview.InjuriesContributions - employee.EmployeeFinancialMetrics.InjuriesContributions, 2);
            preview.ExpensesDelta = Math.Round(preview.Expenses - employee.EmployeeFinancialMetrics.Expenses, 2);
            preview.ProfitDelta = Math.Round(preview.Profit - employee.EmployeeFinancialMetrics.Profit, 2);
            preview.ProfitAbilityDelta = Math.Round(preview.ProfitAbility - employee.EmployeeFinancialMetrics.ProfitAbility, 2);
            preview.GrossSalaryDelta = Math.Round(preview.GrossSalary - employee.EmployeeFinancialMetrics.GrossSalary, 2);
            preview.RetainerDelta = Math.Round(preview.Retainer - employee.EmployeeFinancialMetrics.Retainer, 2);
            preview.NetSalaryDelta = Math.Round(preview.NetSalary - employee.EmployeeFinancialMetrics.NetSalary, 2);

            return preview;
        }
    }
}