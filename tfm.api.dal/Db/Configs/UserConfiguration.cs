using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.MiddleName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.HasMany(c => c.Contacts).WithOne(u => u.User).HasForeignKey(_ => _.Id);
            builder.HasMany(u => u.Roles).WithMany(u => u.Users);
        }
    }
}