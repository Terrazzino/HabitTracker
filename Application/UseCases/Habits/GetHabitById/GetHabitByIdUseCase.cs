using Application.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.GetHabitById
{
     public sealed class GetHabitByIdUseCase
    {
        private readonly IHabitRepository _habitRepository;
        public GetHabitByIdUseCase(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }
        public async Task<HabitDetailResponse?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var habit = await _habitRepository.GetByIdWithEntriesAsync(id, cancellationToken);

            if (habit is null)
                return null;

            return new HabitDetailResponse
            {
                Id = habit.Id,
                Name = habit.Name,
                IsActive = habit.IsActive,
                CurrentStreak = habit.GetCurrentStreak(),
                Entries = habit.Entries
                .Select(e => new HabitEntryResponse
                {
                    Date = e.Date,
                    IsCompleted = e.IsCompleted
                })
                .OrderBy(e => e.Date)
                .ToList()
            };
        }
    }
}
