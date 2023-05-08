using core_application.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace core_application.Repositories.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        //essa abordagem é a mesma coisa que o onModelCreating. A diferença é que fica mais organizado
        public void Configure(EntityTypeBuilder<Account> builder)
        {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Balance).IsRequired();
                builder.HasMany(old => old.OldBalances).WithOne().HasForeignKey(foregin => foregin.AccountId);
        }
    }
}
