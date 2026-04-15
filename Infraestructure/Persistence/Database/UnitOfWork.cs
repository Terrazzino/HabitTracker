using Application.Abstraction.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Database
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly HabitTrackerDbContext _context;
        public UnitOfWork(HabitTrackerDbContext habitTrackerDbContext)
        {
            _context = habitTrackerDbContext;
        }
        public Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
