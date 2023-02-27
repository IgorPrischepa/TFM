using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class MasterConfiguration : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.HasOne(u=>u.User).WithOne();
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.UserId).IsUnique();
        }
    }
}
