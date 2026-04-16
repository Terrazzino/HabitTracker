using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Habit
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreateAt { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<HabitEntry> _entries = new();
        public IReadOnlyCollection<HabitEntry> Entries => _entries.AsReadOnly();

        public Habit(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreateAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new DomainException("Habit name cannot be empty.");
            }
            Name = newName;
        }
        public void Activate()
        {
            IsActive = true;
        }

        public void Desactivate()
        {
            IsActive = false;
        }

        public void MarkAsCompleted(DateOnly date)
        {
            if (_entries.Any(e=>e.Date==date))
            {
                throw new InvalidOperationException("Habit already completed for this date.");
            }
            var entry = new HabitEntry(Id, date);
            _entries.Add(entry);
        }

        public int GetCurrentStreak()
        {
            if (!_entries.Any())
                return 0;
            var completedDates = _entries.Where(e=>e.IsCompleted).Select(e=>e.Date).Distinct().OrderByDescending(d=>d).ToList();
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            int streak = 0;
            var currentDay = today;
            foreach (var date in completedDates)
            {
                if(date == currentDay)
                {
                    streak++;
                    currentDay = currentDay.AddDays(-1);
                }
                else if (date < currentDay)
                {
                    break;
                }
            }
            return streak;
        }
    }
}
