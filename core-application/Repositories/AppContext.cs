using core_application.Models.Account;
using core_application.Models.Deposits;
using core_application.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class AppContext<T>: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OldBalance> OldBalances { get; set; }
        public DbSet<Deposit<T>> Deposits { get; set; }
        public DbSet<Expense<T>> Expenses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=NT20\ROBSONDB;Initial Catalog=Finance;Persist Security Info=True;User ID=sa;Password=R55108105");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Balance).IsRequired();
                a.HasMany(old => old.OldBalances).WithOne().HasForeignKey(foregin => foregin.AccountId);
            });

            modelBuilder.Entity<OldBalance>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.OldBalanceValue).IsRequired();
                a.HasOne(acc => acc.Account).WithMany().HasPrincipalKey(foregin => foregin.Id);
            });
        }
    }
}
