using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HabitEntry
    {
        public Guid Id { get; private set; }
        public Guid HabitId { get; private set; }
        public Habit Habit { get; private set; } = null!;
        public DateOnly Date { get; private set; }
        public bool IsCompleted { get; private set; }
        private HabitEntry() { }
        internal HabitEntry(Guid habitId, DateOnly date)
        {
            HabitId = habitId;
            Date = date;
            IsCompleted = true;
        }

    }
}
