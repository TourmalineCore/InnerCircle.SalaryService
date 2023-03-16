﻿using SalaryService.Domain;

namespace SalaryService.Application.Dtos
{
    public readonly struct EmployeeProfileDto
    {
        public long Id { get; init; }

        public string FullName { get; init; }

        public string CorporateEmail { get; init; }

        public string? PersonalEmail { get; init; }

        public string? Phone { get; init; }

        public string? GitHub { get; init; }

        public string? GitLab { get; init; }

        public EmployeeProfileDto(Employee employee)
        {
            Id = employee.Id;
            FullName = employee.GetFullName();
            CorporateEmail = employee.CorporateEmail;
            PersonalEmail = employee.PersonalEmail;
            Phone = employee.Phone;
            GitHub = employee.GitHub;
            GitLab = employee.GitLab;
        }
    }
}
