﻿
namespace SalaryService.Application.Dtos
{
    public class EmployeeGeneralInformationDto
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string MiddleName { get; private set; }

        public string WorkEmail { get; private set; }

        public string PersonalEmail { get; private set; }

        public string Phone { get; private set; }

        public string Skype { get; private set; }

        public string Telegram { get; private set; }

        public EmployeeGeneralInformationDto(long id, string name, string surname, string middleName, string workEmail, string personalEmail, string phone, string skype, string telegram)
        {
            Id = id;
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            WorkEmail = workEmail;
            PersonalEmail = personalEmail;
            Phone = phone;
            Skype = skype;
            Telegram = telegram;
        }
    }
}