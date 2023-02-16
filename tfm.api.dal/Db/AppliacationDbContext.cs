﻿using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Entities;

namespace tfm.api.dal.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Example> Examples { get; set; } = null!;

        public DbSet<PhotoFile> PhotoFiles { get; set; } = null!;

        public DbSet<Master> Masters { get; set; } = null!;

        public DbSet<StylePrice> StylePrices { get; set; } = null!;

        public DbSet<Style> Styles { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

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
        }
    }
}
