using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db.Configs;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<ContactEntity> Contacts { get; set; } = null!;

        public DbSet<RoleEntity> Roles { get; set; } = null!;

        public DbSet<ExampleEntity> Examples { get; set; } = null!;

        public DbSet<PhotoFileEntity> PhotoFiles { get; set; } = null!;

        public DbSet<MasterEntity> Masters { get; set; } = null!;

        public DbSet<StylePriceEntity> StylePrices { get; set; } = null!;

        public DbSet<StyleEntity> Styles { get; set; } = null!;

        public DbSet<BookingEntity> Bookings { get; set; } = null!;

        public DbSet<CustomerEntity> Customers { get; set; } = null!;

        public DbSet<ScheduleEntity> Schedule { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ExampleConfiguration());
            modelBuilder.ApplyConfiguration(new MasterConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new StylePriceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        }
    }
}