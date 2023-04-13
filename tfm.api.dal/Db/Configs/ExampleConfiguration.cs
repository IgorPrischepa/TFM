using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    internal class ExampleConfiguration : IEntityTypeConfiguration<ExampleEntity>
    {
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
            builder.HasOne(u => u.PhotoFile)
                   .WithOne(e => e.Example)
                   .HasForeignKey<PhotoFileEntity>(k => k.ExampleId);
        }
    }
}
