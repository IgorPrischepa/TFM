using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db.Configs;

public class ScheduleConfiguration : IEntityTypeConfiguration<ScheduleEntity>
{
    public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
    {
        builder.HasOne(_ => _.Master)
            .WithMany(_ => _.Schedules)
            .HasForeignKey(_ => _.MasterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}