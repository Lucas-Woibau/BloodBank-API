using BloodBank.Application;
using BloodBank.Infrastructure;
using BloodBank_API.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationModule()
    .AddExceptionHandler<ApiExceptionHandler>()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

