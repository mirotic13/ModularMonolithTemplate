using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.API.Configuration;
using ModularMonolithTemplate.SharedKernel.Filters;
using ModularMonolithTemplate.SharedKernel.Logging;
using ModularMonolithTemplate.SharedKernel.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();
builder.Services.AddLogService();

builder.ConfigureModules();

builder.Services.AddAuthorization();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ModelValidationFilter>();
    options.Filters.Add<ActionTimingFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
