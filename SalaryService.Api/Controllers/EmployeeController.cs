﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaryService.Application.Dtos;
using SalaryService.Application.Queries;
using SalaryService.Application.Services;
using TourmalineCore.AspNetCore.JwtAuthentication.Core.Filters;

namespace SalaryService.Api.Controllers
{ 
    [Authorize]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly GetEmployeeQueryHandler _getEmployeeQueryHandler;
        private readonly GetEmployeeProfileQueryHandler _getEmployeeProfileQueryHandler;
        private readonly GetEmployeesQueryHandler _getEmployeesQueryHandler;
        private readonly GetEmployeeContactDetailsQueryHandler _getEmployeeContactDetailsQueryHandler;
        private readonly GetEmployeeFinanceForPayrollQueryHandler _getEmployeeFinanceForPayrollQueryHandler;

        public EmployeeController(EmployeeService employeeService,
        GetEmployeeQueryHandler getEmployeeQueryHandler,
        GetEmployeesQueryHandler getEmployeesQueryHandler, 
        GetEmployeeContactDetailsQueryHandler getEmployeeContactDetailsQueryHandler,
        GetEmployeeFinanceForPayrollQueryHandler getEmployeeFinanceForPayrollQueryHandler,
        GetEmployeeProfileQueryHandler getEmployeeProfileQueryHandler)
        {
            _employeeService = employeeService;
            _getEmployeeQueryHandler = getEmployeeQueryHandler;
            _getEmployeesQueryHandler = getEmployeesQueryHandler;
            _getEmployeeContactDetailsQueryHandler = getEmployeeContactDetailsQueryHandler;
            _getEmployeeFinanceForPayrollQueryHandler = getEmployeeFinanceForPayrollQueryHandler;
            _getEmployeeProfileQueryHandler = getEmployeeProfileQueryHandler;
        }

        [HttpGet("get-profile")]
        public Task<EmployeeProfileDto> GetProfileAsync()
        {
            return _getEmployeeProfileQueryHandler.HandleAsync(User.GetCorporateEmail());
        }

        [HttpGet("all")]
        public Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var includeEmployeeFinanceInfo = User.HasClaim(x => x is
            {
                Type: UserClaimsProvider.PermissionClaimType,
                Value: UserClaimsProvider.CanViewFinanceForPayrollPermission
            });

            return _getEmployeesQueryHandler.HandleAsync(includeEmployeeFinanceInfo);
        }

        [RequiresPermission(UserClaimsProvider.CanManageEmployeesPermission)]
        [HttpPut("update")]
        public Task UpdateEmployeeAsync([FromBody] EmployeeUpdateParameters employeeUpdateParameters)
        {
            return _employeeService.UpdateEmployeeAsync(employeeUpdateParameters);
        }

        [RequiresPermission(UserClaimsProvider.CanManageEmployeesPermission)]
        [HttpGet("{employeeId:long}")]
        public Task<EmployeeDto> GetEmployeeAsync([FromRoute] long employeeId)
        {
            return _getEmployeeQueryHandler.HandleAsync(employeeId);
        }

        [RequiresPermission(UserClaimsProvider.CanManageEmployeesPermission)]
        [HttpPut("update-profile")]
        public Task UpdateProfile([FromBody] ProfileUpdatingParameters profileUpdatingParameters)
        {
            return _employeeService.UpdateProfileAsync(profileUpdatingParameters);
        }
        
        [RequiresPermission(UserClaimsProvider.CanManageEmployeesPermission)]
        [HttpGet("get-finance-for-payroll/{employeeId}")]
        public Task<ColleagueFinancesDto> GetFinanceForPayroll([FromRoute] long employeeId)
        {
            return _getEmployeeFinanceForPayrollQueryHandler.HandleAsync(employeeId);
        }
        
        [RequiresPermission(UserClaimsProvider.CanManageEmployeesPermission)]
        [HttpGet("get-contact-details/{employeeId}")]
        public Task<ColleagueContactsDto> GetContactDetails([FromRoute] long employeeId)
        {
            return _getEmployeeContactDetailsQueryHandler.HandleAsync(employeeId);
        }

        [RequiresPermission(UserClaimsProvider.CanManageEmployeesPermission)]
        [HttpDelete("delete/{id}")]
        public Task DeleteEmployee([FromRoute] long id)
        {
            return _employeeService.DeleteEmployee(id);
        }
    }
}
