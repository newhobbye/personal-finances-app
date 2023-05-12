﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using core_application.Repositories;

#nullable disable

namespace core_application.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("core_application.Models.Account.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("core_application.Models.Account.OldBalance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BalanceDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("OldBalanceValue")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("OldBalances");
                });

            modelBuilder.Entity("core_application.Models.Deposits.Deposit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("core_application.Models.Expenses.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("core_application.Models.UserCategories.UserDepositCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepositId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepositId")
                        .IsUnique();

                    b.ToTable("UserDepositCategories");
                });

            modelBuilder.Entity("core_application.Models.UserCategories.UserExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId")
                        .IsUnique();

                    b.ToTable("UserExpenseCategories");
                });

            modelBuilder.Entity("core_application.Models.Account.OldBalance", b =>
                {
                    b.HasOne("core_application.Models.Account.Account", null)
                        .WithMany("OldBalances")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("core_application.Models.UserCategories.UserDepositCategory", b =>
                {
                    b.HasOne("core_application.Models.Deposits.Deposit", "Deposit")
                        .WithOne("UserCategory")
                        .HasForeignKey("core_application.Models.UserCategories.UserDepositCategory", "DepositId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("core_application.Models.UserCategories.UserExpenseCategory", b =>
                {
                    b.HasOne("core_application.Models.Expenses.Expense", "Expense")
                        .WithOne("UserCategory")
                        .HasForeignKey("core_application.Models.UserCategories.UserExpenseCategory", "ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expense");
                });

            modelBuilder.Entity("core_application.Models.Account.Account", b =>
                {
                    b.Navigation("OldBalances");
                });

            modelBuilder.Entity("core_application.Models.Deposits.Deposit", b =>
                {
                    b.Navigation("UserCategory")
                        .IsRequired();
                });

            modelBuilder.Entity("core_application.Models.Expenses.Expense", b =>
                {
                    b.Navigation("UserCategory")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
