using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;

namespace Persons.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>, IMapping
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired().HasColumnName("Last_Name");

            builder.Property(u => u.Cpf)
                .HasColumnType("varchar(20)")
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(u => u.Email);

            builder.Property(u => u.Roles).HasColumnType("smallint");

            builder.Property(u => u.Status).HasColumnType("smallint");
        }
    }
}
