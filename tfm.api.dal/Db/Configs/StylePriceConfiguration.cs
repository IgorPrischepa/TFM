using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Models;

namespace tfm.api.dal.Db
{
    internal class StylePriceConfiguration : IEntityTypeConfiguration<StylePrice>
    {
        public void Configure(EntityTypeBuilder<StylePrice> builder)
        {
            builder.HasOne(u => u.Master);
            builder.HasOne(u => u.Style);
        }
    }
}
