using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementation;

public class ScheduleRepo : IScheduleRepo
{
    private readonly ApplicationDbContext _db;

    public ScheduleRepo(ApplicationDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<int> AddAsync(ScheduleEntity schedule)
    {
        if (schedule == null) throw new ArgumentNullException(nameof(schedule));

        await _db.Schedule.AddAsync(schedule);

        await _db.SaveChangesAsync();

        return schedule.Id;
    }

    public async Task DeleteAsync(int id)
    {
        ScheduleEntity? entity = await _db.Schedule.FirstOrDefaultAsync(_ => _.Id == id);

        if (entity == null)
        {
            return;
        }

        _db.Remove(entity);

        await _db.SaveChangesAsync();
    }

    public Task<ScheduleEntity?> GetAsync(int id)
    {
        return _db.Schedule.FirstOrDefaultAsync(_ => _.Id == id);
    }
}