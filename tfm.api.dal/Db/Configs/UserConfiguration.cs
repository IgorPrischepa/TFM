using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.MiddleName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.HasMany(c => c.Contacts).WithOne(u => u.User).HasForeignKey(_ => _.Id);
            builder.HasMany(u => u.Roles).WithMany(u => u.Users);
        }
    }
}