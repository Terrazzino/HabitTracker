using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.CompleteHabit
{
    public sealed class CompleteHabitRequest
    {
        public Guid HabitId {  get; init; }
    }
}
