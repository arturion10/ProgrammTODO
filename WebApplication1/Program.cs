using FluentValidation;
using FluentValidation.AspNetCore;
using ProgrammTODO.Bll.Services;
using ProgrammTODO.Dal;
using WebUI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<TaskService>();
builder.Services.AddTransient<GroupService>();
builder.Services.AddTransient<ApplicationContext>();
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TaskCreationModelValidator>());
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GroupCreationModelValidator>());
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
