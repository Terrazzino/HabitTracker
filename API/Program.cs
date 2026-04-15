using API.Midleware;
using Application.Abstraction.Persistence;
using Application.Abstraction.Repositories;
using Application.UseCases.Habits.CompleteHabit;
using Application.UseCases.Habits.CreateHabit;
using Application.UseCases.Habits.GetHabitById;
using Application.UseCases.Habits.GetHabits;
using Infraestructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<HabitTrackerDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHabitRepository, HabitRepository>();

builder.Services.AddScoped<CreateHabitUseCase>();

builder.Services.AddScoped<GetHabitsUseCase>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<CompleteHabitForTodayUseCase>();
builder.Services.AddScoped<GetHabitByIdUseCase>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
