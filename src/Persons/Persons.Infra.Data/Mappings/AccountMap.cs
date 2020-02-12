using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;

namespace Persons.Infra.Data.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>, IMapping
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts", "Account");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(c => c.Login)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired().HasColumnName("Login");

            builder.Property(c => c.Password)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired().HasColumnName("Password");
            
            builder.Property(c => c.Status).HasColumnType("smallint");

            builder.HasIndex(c => c.Login).IsUnique();

            builder.Property(c => c.IdUser)
                .HasMaxLength(100)
                .IsRequired().HasColumnName("Id_User");

            builder.HasOne(u => u.User).WithMany().HasForeignKey(c => c.IdUser);

        }
    }
}
