using Application.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.GetHabits
{
    public sealed class GetHabitsUseCase
    {
        private readonly IHabitRepository _habitRepository;
        public GetHabitsUseCase (IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }
        public async Task<List<GetHabitsResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var habits = await _habitRepository.GetAllAsync(cancellationToken);
            return habits.Select(h => new GetHabitsResponse
            {
                Id = h.Id,
                Name = h.Name,
                IsActive = h.IsActive,
                CreatedAt = h.CreateAt,
            }).ToList();
        }
    }
}
