using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { Id = 1, Name = "Admin" });
            builder.HasData(new Role { Id = 2, Name = "Customer" });
            builder.HasData(new Role { Id = 3, Name = "Master" });
            builder.HasMany(u => u.Users);
        }
    }
}