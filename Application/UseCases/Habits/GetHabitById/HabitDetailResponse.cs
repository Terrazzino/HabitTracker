using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.GetHabitById
{
    public sealed class HabitDetailResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public bool IsActive { get; init; }
        public List<HabitEntryResponse> Entries { get; init; } = new(); 
    }
}
