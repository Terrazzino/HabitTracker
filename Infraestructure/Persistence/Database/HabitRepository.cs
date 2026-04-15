using Application.Abstraction.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Database
{
    public class HabitRepository:IHabitRepository
    {
        private readonly HabitTrackerDbContext _context;
        public HabitRepository(HabitTrackerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Habit habit, CancellationToken cancellationToken)
        {
            await _context.AddAsync(habit,cancellationToken);
        }
        public async Task<Habit?> GetByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            return await _context.Habits.FirstOrDefaultAsync(h=>h.Id==id,cancellationToken);
        }
        public async Task<List<Habit>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Habits.AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<Habit?> GetByIdWithEntriesAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Habits.Include(h => h.Entries).FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
        }
    }
}
