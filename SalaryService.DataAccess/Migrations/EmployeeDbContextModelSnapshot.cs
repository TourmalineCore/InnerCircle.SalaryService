﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalaryService.DataAccess;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("CorporateEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GitHub")
                        .HasColumnType("text");

                    b.Property<string>("GitLab")
                        .HasColumnType("text");

                    b.Property<Instant>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonalEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CorporateEmail")
                        .IsUnique();

                    b.HasIndex("GitHub")
                        .IsUnique();

                    b.HasIndex("GitLab")
                        .IsUnique();

                    b.HasIndex("PersonalEmail")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 50L,
                            AccountId = 1L,
                            CorporateEmail = "ceo@tourmalinecore.com",
                            GitHub = "@ceo.github",
                            GitLab = "@ceo.gitlab",
                            HireDate = NodaTime.Instant.FromUnixTimeTicks(0L),
                            MiddleName = "Ceo",
                            Name = "Ceo",
                            PersonalEmail = "ceo@gmail.com",
                            Phone = "88006663636",
                            Surname = "Ceo"
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinanceForPayroll", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("EmploymentType")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ParkingCostPerMonth")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Pay")
                        .HasColumnType("numeric");

                    b.Property<decimal>("RatePerHour")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeFinanceForPayroll");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetrics", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("AccountingPerMonth")
                        .HasColumnType("numeric");

                    b.Property<Instant>("ActualFromUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("DistrictCoefficient")
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

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeFinancialMetrics");
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

            modelBuilder.Entity("TotalFinances", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Instant>("ActualFromUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PayrollExpense")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalExpense")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("TotalFinances");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinanceForPayroll", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithOne("EmployeeFinanceForPayroll")
                        .HasForeignKey("SalaryService.Domain.EmployeeFinanceForPayroll", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetrics", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithOne("EmployeeFinancialMetrics")
                        .HasForeignKey("SalaryService.Domain.EmployeeFinancialMetrics", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
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

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Navigation("EmployeeFinanceForPayroll")
                        .IsRequired();

                    b.Navigation("EmployeeFinancialMetrics")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
