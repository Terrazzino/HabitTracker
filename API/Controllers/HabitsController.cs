using Application.UseCases.Habits.CompleteHabit;
using Application.UseCases.Habits.CreateHabit;
using Application.UseCases.Habits.GetHabitById;
using Application.UseCases.Habits.GetHabits;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitsController:ControllerBase
    {
        private readonly CreateHabitUseCase _createHabitUseCase;
        private readonly GetHabitsUseCase _getHabitsUseCase;
        private readonly CompleteHabitForTodayUseCase _completeHabitForTodayUseCase;
        private readonly GetHabitByIdUseCase _getHabitByIdUseCase;
        public HabitsController(CreateHabitUseCase createHabitUseCase, GetHabitsUseCase getHabitUseCase, CompleteHabitForTodayUseCase completeHabitForTodayUseCase, GetHabitByIdUseCase getHabitByIdUseCase)
        {
            _createHabitUseCase = createHabitUseCase;
            _getHabitsUseCase = getHabitUseCase;
            _completeHabitForTodayUseCase = completeHabitForTodayUseCase;
            _getHabitByIdUseCase = getHabitByIdUseCase;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHabitRequest request,CancellationToken cancellationToken)
        {
            var id = await _createHabitUseCase.ExecuteAsync(request, cancellationToken);
            return Ok(new { Id=id});
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var habits = await _getHabitsUseCase.ExecuteAsync(cancellationToken);
            return Ok(habits);
        }
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
        {
            await _completeHabitForTodayUseCase.ExecuteAsyn(new CompleteHabitRequest { HabitId = id }, cancellationToken);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var habit = await _getHabitByIdUseCase.ExecuteAsync(id, cancellationToken);
            if (habit is null) return NotFound();
            return Ok(habit);
        }
    }
}
