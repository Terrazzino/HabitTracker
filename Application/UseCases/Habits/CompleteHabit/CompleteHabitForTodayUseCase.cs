using Application.Abstraction.Persistence;
using Application.Abstraction.Repositories;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.CompleteHabit
{
    public sealed class CompleteHabitForTodayUseCase
    {
        private readonly IHabitRepository _habitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteHabitForTodayUseCase(IHabitRepository habitRepository, IUnitOfWork unitOfWork)
        {
            _habitRepository = habitRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsyn(CompleteHabitRequest request, CancellationToken cancellationToken)
        {
            var habit = await _habitRepository.GetByIdWithEntriesAsync(request.HabitId, cancellationToken);
            if (habit is null)
            {
                throw new NotFoundException("Habit not found");
            }
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            habit.MarkAsCompleted(today);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
