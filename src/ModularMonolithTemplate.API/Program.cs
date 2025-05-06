using ModularMonolithTemplate.API.Configuration;
using ModularMonolithTemplate.BuildingBlocks.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();

builder.ConfigureModules();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var app = builder.Build();

app.UseCustomSerilogExceptionHandler();
app.UseCustomRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
