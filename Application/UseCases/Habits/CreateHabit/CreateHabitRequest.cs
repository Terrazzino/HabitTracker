using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.CreateHabit
{
    public sealed class CreateHabitRequest
    {
        public string Name { get; init; } = default!;
    }
}
