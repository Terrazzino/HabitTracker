using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Database
{
    public class HabitTrackerDbContext:DbContext
    {
        public HabitTrackerDbContext(DbContextOptions<HabitTrackerDbContext> options):base(options)
        {

        }
        public DbSet<Habit> Habits => Set<Habit>();
        public DbSet<HabitEntry> HabitEntries => Set<HabitEntry>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(h => h.CreateAt)
                    .IsRequired();

                entity.Property(h => h.IsActive)
                    .IsRequired();

                entity.HasMany(h => h.Entries)
                    .WithOne(e => e.Habit)
                    .HasForeignKey(e => e.HabitId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Metadata
                    .FindNavigation(nameof(Habit.Entries))!
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<HabitEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.IsCompleted).IsRequired();
            });
        }
    }
}
