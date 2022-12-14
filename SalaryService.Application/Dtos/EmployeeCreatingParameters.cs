using SalaryService.Domain;

namespace SalaryService.Application.Dtos
{
    public partial class EmployeeCreatingParameters
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string CorporateEmail { get; set; }

        public string PersonalEmail { get; set; }

        public string Phone { get; set; }

        public string GitHub { get; set; }

        public string GitLab { get; set; }

        public double RatePerHour { get; set; }

        public double Pay { get; set; }

        public EmploymentTypes EmploymentType { get; set; }

        public double EmploymentTypeValue => EmploymentType == EmploymentTypes.FullTime ? 1.0 : 0.5;

        public double ParkingCostPerMonth { get; set; }
    }
}
