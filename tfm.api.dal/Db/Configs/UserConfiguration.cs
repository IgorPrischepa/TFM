using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(c => c.Contacts).WithOne(u => u.User).HasForeignKey(_ => _.Id);
            builder.HasMany(u => u.Roles).WithMany(u => u.Users);
        }
    }
}