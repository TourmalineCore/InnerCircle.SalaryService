﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalaryService.DataAccess;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20231017043730_AddCompensations")]
    partial class AddCompensations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalaryService.Domain.CoefficientOptions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("DistrictCoefficient")
                        .HasColumnType("numeric");

                    b.Property<decimal>("IncomeTaxPercent")
                        .HasColumnType("numeric");

                    b.Property<decimal>("MinimumWage")
                        .HasColumnType("numeric");

                    b.Property<decimal>("OfficeExpenses")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("CoefficientOptions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DistrictCoefficient = 0.15m,
                            IncomeTaxPercent = 0.13m,
                            MinimumWage = 15279m,
                            OfficeExpenses = 49000m
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.Compensation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Compensations");
                });

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CorporateEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GitHub")
                        .HasColumnType("text");

                    b.Property<string>("GitLab")
                        .HasColumnType("text");

                    b.Property<Instant?>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsBlankEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsCurrentEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsEmployedOfficially")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsSpecial")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("PersonalEmail")
                        .HasColumnType("text");

                    b.Property<string>("PersonnelNumber")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CorporateEmail")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CorporateEmail = "ceo@tourmalinecore.com",
                            FirstName = "Ceo",
                            GitHub = "@ceo.github",
                            GitLab = "@ceo.gitlab",
                            HireDate = NodaTime.Instant.FromUnixTimeTicks(15778368000000000L),
                            IsBlankEmployee = true,
                            IsCurrentEmployee = true,
                            IsEmployedOfficially = true,
                            IsSpecial = false,
                            LastName = "Ceo",
                            MiddleName = "Ceo",
                            PersonalEmail = "ceo@gmail.com",
                            Phone = "88006663636"
                        },
                        new
                        {
                            Id = 2L,
                            CorporateEmail = "inner-circle-admin@tourmalinecore.com",
                            FirstName = "Admin",
                            HireDate = NodaTime.Instant.FromUnixTimeTicks(15778368000000000L),
                            IsBlankEmployee = true,
                            IsCurrentEmployee = true,
                            IsEmployedOfficially = true,
                            IsSpecial = true,
                            LastName = "Admin",
                            MiddleName = "Admin",
                            PersonalEmail = "inner-circle-admin@gmail.com"
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetricsHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("AccountingPerMonth")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Earnings")
                        .HasColumnType("numeric");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("EmploymentType")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Expenses")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("numeric");

                    b.Property<decimal>("HourlyCostFact")
                        .HasColumnType("numeric");

                    b.Property<decimal>("HourlyCostHand")
                        .HasColumnType("numeric");

                    b.Property<decimal>("IncomeTaxContributions")
                        .HasColumnType("numeric");

                    b.Property<decimal>("InjuriesContributions")
                        .HasColumnType("numeric");

                    b.Property<decimal>("MedicalContributions")
                        .HasColumnType("numeric");

                    b.Property<decimal>("NetSalary")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ParkingCostPerMonth")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Pay")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PensionContributions")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Prepayment")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Profit")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ProfitAbility")
                        .HasColumnType("numeric");

                    b.Property<decimal>("RatePerHour")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SocialInsuranceContributions")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeFinancialMetricsHistory");
                });

            modelBuilder.Entity("SalaryService.Domain.EstimatedFinancialEfficiency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Instant>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("DesiredEarnings")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DesiredProfit")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DesiredProfitability")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ReserveForHalfYear")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ReserveForQuarter")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ReserveForYear")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("EstimatedFinancialEfficiency");
                });

            modelBuilder.Entity("SalaryService.Domain.TotalFinances", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Instant>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PayrollExpense")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalExpense")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("TotalFinances");
                });

            modelBuilder.Entity("SalaryService.Domain.TotalFinancesHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("PayrollExpense")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalExpense")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("TotalFinancesHistory");
                });

            modelBuilder.Entity("SalaryService.Domain.WorkingPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("WorkingDaysInMonth")
                        .HasColumnType("numeric");

                    b.Property<decimal>("WorkingDaysInYear")
                        .HasColumnType("numeric");

                    b.Property<decimal>("WorkingDaysInYearWithoutVacation")
                        .HasColumnType("numeric");

                    b.Property<decimal>("WorkingDaysInYearWithoutVacationAndSick")
                        .HasColumnType("numeric");

                    b.Property<decimal>("WorkingHoursInMonth")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("WorkingPlan");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            WorkingDaysInMonth = 16.916666666666666666666666667m,
                            WorkingDaysInYear = 247m,
                            WorkingDaysInYearWithoutVacation = 223m,
                            WorkingDaysInYearWithoutVacationAndSick = 203m,
                            WorkingHoursInMonth = 135.33333333333333333333333334m
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.OwnsOne("SalaryService.Domain.EmployeeFinancialMetrics", "FinancialMetrics", b1 =>
                        {
                            b1.Property<long>("EmployeeId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("AccountingPerMonth")
                                .HasColumnType("numeric")
                                .HasColumnName("AccountingPerMonth");

                            b1.Property<Instant>("CreatedAtUtc")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<decimal>("DistrictCoefficient")
                                .HasColumnType("numeric")
                                .HasColumnName("DistrictCoefficient");

                            b1.Property<decimal>("Earnings")
                                .HasColumnType("numeric")
                                .HasColumnName("Earnings");

                            b1.Property<decimal>("EmploymentType")
                                .HasColumnType("numeric")
                                .HasColumnName("EmploymentType");

                            b1.Property<decimal>("Expenses")
                                .HasColumnType("numeric")
                                .HasColumnName("Expenses");

                            b1.Property<decimal>("GrossSalary")
                                .HasColumnType("numeric")
                                .HasColumnName("GrossSalary");

                            b1.Property<decimal>("HourlyCostFact")
                                .HasColumnType("numeric")
                                .HasColumnName("HourlyCostFact");

                            b1.Property<decimal>("HourlyCostHand")
                                .HasColumnType("numeric")
                                .HasColumnName("HourlyCostHand");

                            b1.Property<decimal>("IncomeTaxContributions")
                                .HasColumnType("numeric")
                                .HasColumnName("IncomeTaxContributions");

                            b1.Property<decimal>("InjuriesContributions")
                                .HasColumnType("numeric");

                            b1.Property<decimal>("MedicalContributions")
                                .HasColumnType("numeric")
                                .HasColumnName("MedicalContributions");

                            b1.Property<decimal>("NetSalary")
                                .HasColumnType("numeric")
                                .HasColumnName("NetSalary");

                            b1.Property<decimal>("ParkingCostPerMonth")
                                .HasColumnType("numeric")
                                .HasColumnName("ParkingCostPerMonth");

                            b1.Property<decimal>("Pay")
                                .HasColumnType("numeric")
                                .HasColumnName("Pay");

                            b1.Property<decimal>("PensionContributions")
                                .HasColumnType("numeric")
                                .HasColumnName("PensionContributions");

                            b1.Property<decimal>("Prepayment")
                                .HasColumnType("numeric")
                                .HasColumnName("Prepayment");

                            b1.Property<decimal>("Profit")
                                .HasColumnType("numeric")
                                .HasColumnName("Profit");

                            b1.Property<decimal>("ProfitAbility")
                                .HasColumnType("numeric")
                                .HasColumnName("ProfitAbility");

                            b1.Property<decimal>("RatePerHour")
                                .HasColumnType("numeric")
                                .HasColumnName("RatePerHour");

                            b1.Property<decimal>("Salary")
                                .HasColumnType("numeric")
                                .HasColumnName("Salary");

                            b1.Property<decimal>("SocialInsuranceContributions")
                                .HasColumnType("numeric")
                                .HasColumnName("SocialInsuranceContributions");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("EmployeeFinancialMetrics", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("FinancialMetrics");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetricsHistory", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SalaryService.Domain.Common.Period", "Period", b1 =>
                        {
                            b1.Property<long>("EmployeeFinancialMetricsHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<Instant>("FromUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("FromUtc");

                            b1.Property<Instant?>("ToUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("ToUtc");

                            b1.HasKey("EmployeeFinancialMetricsHistoryId");

                            b1.ToTable("EmployeeFinancialMetricsHistory");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeFinancialMetricsHistoryId");
                        });

                    b.Navigation("Employee");

                    b.Navigation("Period")
                        .IsRequired();
                });

            modelBuilder.Entity("SalaryService.Domain.TotalFinancesHistory", b =>
                {
                    b.OwnsOne("SalaryService.Domain.Common.Period", "Period", b1 =>
                        {
                            b1.Property<long>("TotalFinancesHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<Instant>("FromUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("FromUtc");

                            b1.Property<Instant?>("ToUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("ToUtc");

                            b1.HasKey("TotalFinancesHistoryId");

                            b1.ToTable("TotalFinancesHistory");

                            b1.WithOwner()
                                .HasForeignKey("TotalFinancesHistoryId");
                        });

                    b.Navigation("Period")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
