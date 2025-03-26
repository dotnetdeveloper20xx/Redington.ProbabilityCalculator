using FluentValidation;
using FluentValidation.AspNetCore;
using Redington.ProbabilityCalculator.Core.DTOs;
using Redington.ProbabilityCalculator.Core.Interfaces;
using Redington.ProbabilityCalculator.Core.Services;
using Redington.ProbabilityCalculator.Api.Validators;
using Microsoft.OpenApi.Models;
using Redington.ProbabilityCalculator.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddScoped<IProbabilityCalculator, ProbabilityCalculator>();
builder.Services.AddScoped<IValidator<ProbabilityRequestDto>, ProbabilityRequestDtoValidator>();
builder.Services.AddScoped<ICalculationLogger, TextFileCalculationLogger>();


// Add Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Redington Probability Calculator API",
        Version = "v1",
        Description = "API to calculate probability operations for investment consultants"
    });

    // Enables enum values to be shown as strings in Swagger UI
    options.UseInlineDefinitionsForEnums();
});




var app = builder.Build();

// Middlewares
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
