using Microsoft.EntityFrameworkCore;
using SalaryService.Application.Dtos;
using SalaryService.DataAccess;
using SalaryService.Domain;

namespace SalaryService.Application.Commands
{
    public partial class UpdateProfileCommand
    {
    }

    public class UpdateProfileCommandHandler
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public UpdateProfileCommandHandler(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task HandleAsync(ProfileUpdatingParameters request, long accountId)
        {
            var employee = await _employeeDbContext
                .Queryable<Employee>()
                .SingleAsync(x => x.AccountId == accountId && x.DeletedAtUtc == null);

            employee.Update(request.PersonalEmail, request.Phone, request.GitHub, request.GitLab);

            _employeeDbContext.Update(employee);
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
