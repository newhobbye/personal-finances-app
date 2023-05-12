using core_application.Models.Account;
using core_application.Models.Deposits;
using core_application.Models.Environment;
using core_application.Models.Expenses;
using core_application.Models.UserCategories;
using core_application.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OldBalance> OldBalances { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<UserDepositCategory> UserDepositCategories { get; set; }
        public DbSet<UserExpenseCategory> UserExpenseCategories { get; set; }

        public ApplicationContext() 
        {
            //comando que garante a existencia do banco de dados. Mas, após criar o banco, não permite que as migrações funcionem
            //Database.EnsureCreated();

            //já este metodo, permite que as migrações atualizem o banco, e cria ele se não existir
            Database.Migrate();
            //_constants = constants;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Constants.Constant.DatabaseFilename}");
            //optionsBuilder.UseSqlite($"Filename={_constants.DatabaseFilename}");
        }

        //se não me engano, isso é fluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //está assim devido ser uma config externa
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.Entity<OldBalance>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.OldBalanceValue).IsRequired();
            });

            modelBuilder.Entity<Deposit>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Value).IsRequired();
                a.Property(a => a.Status).IsRequired().HasConversion<string>();
                a.Property(a => a.Category).IsRequired().HasConversion<string>();
                a.HasOne(d => d.UserCategory).WithOne(d => d.Deposit).HasForeignKey<UserDepositCategory>(d => d.DepositId);
                
            });

            modelBuilder.Entity<Expense>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Value).IsRequired();
                a.Property(a => a.Status).IsRequired().HasConversion<string>();
                a.Property(a => a.Category).IsRequired().HasConversion<string>();
                a.HasOne(d => d.UserCategory).WithOne(d => d.Expense).HasForeignKey<UserExpenseCategory>(d => d.ExpenseId);
            });

            modelBuilder.Entity<UserDepositCategory>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(p => p.Id).ValueGeneratedOnAdd();
                a.Property(p => p.Category).IsRequired();
            });

            modelBuilder.Entity<UserExpenseCategory>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(p => p.Id).ValueGeneratedOnAdd();
                a.Property(p => p.Category).IsRequired();
            });
        }
    }
}
