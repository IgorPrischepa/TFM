using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class StylePriceConfiguration : IEntityTypeConfiguration<StylePriceEntity>
    {
        public void Configure(EntityTypeBuilder<StylePriceEntity> builder)
        {
            builder.HasOne(u => u.Master);
            builder.HasOne(u => u.Style);
        }
    }
}
