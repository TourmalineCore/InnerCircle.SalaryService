using NodaTime;
using SalaryService.Domain;
using SalaryService.Tests.Data;
using System.Collections;

namespace SalaryService.Tests
{
    public struct CoefficientOptions
    {
        public double DistrictCoefficient = 0.15;
        public double MinimumWage = 15279;
        public double IncomeTaxPercent = 0.13;
        public double OfficeExpenses = 49000.0;
        public double WorkingHoursInMouth = 135.3;

        public CoefficientOptions()
        {
        }
    }
    
    public class EmployeeFinancialMetricsTest
    {
        private readonly CoefficientOptions _coefficientOptions = new();

        [Theory]
        [MemberData(nameof(EmployeeFinancialMetricsTestData.Data), MemberType = typeof(EmployeeFinancialMetricsTestData))]
        public void Test(EmployeeFinancialMetrics employeeFinancialMetricsTest, 
            double ratePerHour, 
            double pay, 
            double employeeType, 
            double parkingCostPerMonth)
        {
            var employeeFinancialMetrics = new EmployeeFinancialMetrics(
                ratePerHour,
                pay,
                employeeType,
                parkingCostPerMonth
            );

            employeeFinancialMetrics.CalculateMetrics(
                _coefficientOptions.DistrictCoefficient,
                _coefficientOptions.MinimumWage,
                _coefficientOptions.IncomeTaxPercent,
                _coefficientOptions.WorkingHoursInMouth,
                new Instant()
            );

            CheckValues(employeeFinancialMetrics, employeeFinancialMetricsTest);
        }

        
        public void CheckValues(EmployeeFinancialMetrics employeeFinancialMetrics, EmployeeFinancialMetrics employeeFinancialMetricsTest)
        {
            Assert.Equal(employeeFinancialMetricsTest.Salary, employeeFinancialMetrics.Salary);
            //Assert.Equal(employeeFinancialMetricsTest.HourlyCostFact, employeeFinancialMetrics.HourlyCostFact);
            //Assert.Equal(employeeFinancialMetricsTest.HourlyCostHand, employeeFinancialMetrics.HourlyCostHand);
            //Assert.Equal(employeeFinancialMetricsTest.Earnings, employeeFinancialMetrics.Earnings); //�����
            Assert.Equal(employeeFinancialMetricsTest.DistrictCoefficient, employeeFinancialMetrics.DistrictCoefficient); //���.����.
            Assert.Equal(employeeFinancialMetricsTest.IncomeTaxContributions, employeeFinancialMetrics.IncomeTaxContributions); //����
            Assert.Equal(employeeFinancialMetricsTest.PensionContributions, employeeFinancialMetrics.PensionContributions); //���
            Assert.Equal(employeeFinancialMetricsTest.MedicalContributions, employeeFinancialMetrics.MedicalContributions); //���
            Assert.Equal(employeeFinancialMetricsTest.SocialInsuranceContributions, employeeFinancialMetrics.SocialInsuranceContributions); //���
            Assert.Equal(employeeFinancialMetricsTest.InjuriesContributions, employeeFinancialMetrics.InjuriesContributions); //������ �� ����������
            Assert.Equal(employeeFinancialMetricsTest.Expenses, employeeFinancialMetrics.Expenses); //������
            //Assert.Equal(employeeFinancialMetricsTest.Profit, employeeFinancialMetrics.Profit); //�������
            //Assert.Equal(employeeFinancialMetricsTest.ProfitAbility, employeeFinancialMetrics.ProfitAbility); //��������������
            Assert.Equal(employeeFinancialMetricsTest.GrossSalary, employeeFinancialMetrics.GrossSalary); //�������� �� ������ ����
            Assert.Equal(employeeFinancialMetricsTest.NetSalary, employeeFinancialMetrics.NetSalary); //��������
            Assert.Equal(employeeFinancialMetricsTest.Prepayment, employeeFinancialMetrics.Prepayment); //������ 
            Assert.Equal(employeeFinancialMetricsTest.AccountingPerMonth, employeeFinancialMetrics.AccountingPerMonth);
        }        
    }
}