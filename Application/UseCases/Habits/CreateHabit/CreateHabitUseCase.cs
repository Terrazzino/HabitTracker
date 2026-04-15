using Application.Abstraction.Persistence;
using Application.Abstraction.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits.CreateHabit
{
    public sealed class CreateHabitUseCase
    {
        private readonly IHabitRepository _habitRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateHabitUseCase(IHabitRepository habitRepository, IUnitOfWork unitOfWork)
        {
            _habitRepository = habitRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> ExecuteAsync(CreateHabitRequest request, CancellationToken cancellationToken)
        {
            var habit = new Habit (request.Name);
            await _habitRepository.AddAsync(habit,cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return habit.Id;
        }
    }
}
