using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.Property(u => u.Name).IsRequired();
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasData(new RoleEntity { Id = 1, Name = "Admin" });
            builder.HasData(new RoleEntity { Id = 2, Name = "Customer" });
            builder.HasData(new RoleEntity { Id = 3, Name = "Master" });
            builder.HasMany(u => u.Users);
        }
    }
}