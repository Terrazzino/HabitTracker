using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.GetHabitById
{
    public sealed class HabitEntryResponse
    {
        public DateOnly Date {  get; init; }
        public bool IsCompleted { get; init; }
    }
}
