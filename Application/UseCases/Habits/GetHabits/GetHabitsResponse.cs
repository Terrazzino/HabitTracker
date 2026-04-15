using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.GetHabits
{
    public sealed class GetHabitsResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public bool IsActive { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
