using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Repositories
{
    public interface IHabitRepository
    {
        Task AddAsync(Habit habit, CancellationToken cancellationToken);
        Task<Habit?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Habit>> GetAllAsync(CancellationToken cancellationToken);
        Task<Habit?> GetByIdWithEntriesAsync(Guid id, CancellationToken cancellationToken);
    }
}
