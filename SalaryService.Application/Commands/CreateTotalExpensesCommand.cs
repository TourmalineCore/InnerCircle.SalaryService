using Microsoft.EntityFrameworkCore;
using NodaTime;
using SalaryService.DataAccess;
using SalaryService.Domain;
using Period = SalaryService.Domain.Common.Period;

namespace SalaryService.Application.Commands
{
    public partial class CreateTotalExpensesCommand
    {
    }

    public class CreateTotalExpensesCommandHandler
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IClock _clock;

        public CreateTotalExpensesCommandHandler(EmployeeDbContext employeeDbContext, 
            IClock clock)
        {
            _employeeDbContext = employeeDbContext;
            _clock = clock;
        }

        public async Task HandleAsync(TotalFinances totalFinances)
        {
            var lastTotals = await _employeeDbContext.Queryable<TotalFinances>().SingleOrDefaultAsync();

            if (lastTotals == null)
            {
                _employeeDbContext.Add(totalFinances);
            }
            else
            {
                var historyTotals = new TotalFinancesHistory
                {
                    Period = new Period(lastTotals.ActualFromUtc, _clock.GetCurrentInstant()),
                    PayrollExpense = lastTotals.PayrollExpense,
                    TotalExpense = lastTotals.TotalExpense
                };
                _employeeDbContext.Add(historyTotals);

                lastTotals.Update(totalFinances.ActualFromUtc, totalFinances.PayrollExpense, totalFinances.TotalExpense);
                _employeeDbContext.Update(lastTotals);
            }
            
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
