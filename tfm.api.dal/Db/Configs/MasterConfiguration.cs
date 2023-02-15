using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Models;

namespace tfm.api.dal.Db
{
    internal class MasterConfiguration : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.HasOne(u => u.User);
        }
    }
}
