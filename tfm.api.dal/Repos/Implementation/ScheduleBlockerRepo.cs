using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementation;

public class ScheduleBlockerRepo : IScheduleBlockerRepo
{
    private readonly ApplicationDbContext _db;

    public ScheduleBlockerRepo(ApplicationDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<int> AddAsync(ScheduleBlockerEntity blockerEntity)
    {
        if (blockerEntity == null) throw new ArgumentNullException(nameof(blockerEntity));

        await _db.ScheduleBlockers.AddAsync(blockerEntity);

        await _db.SaveChangesAsync();

        return blockerEntity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        ScheduleBlockerEntity? blockerEntity = await _db.ScheduleBlockers.FirstOrDefaultAsync(_ => _.Id == id);

        if (blockerEntity != null)
        {
            _db.ScheduleBlockers.Remove(blockerEntity);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<ScheduleBlockerEntity?> GetAsync(int id)
    {
        return await _db.ScheduleBlockers.FirstOrDefaultAsync(_ => _.Id == id);
    }
}