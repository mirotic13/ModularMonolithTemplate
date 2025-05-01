using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Logging;
using ModularMonolithTemplate.Companies.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Users.Infraestructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();

builder.Services
    .AddAuthModule(builder.Configuration)
    .AddCompaniesModule(builder.Configuration)
    .AddUsersModule(builder.Configuration);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomSerilogExceptionHandler();
app.UseCustomRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
