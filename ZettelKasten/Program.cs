using MediatR;
using Microsoft.AspNetCore.Hosting;
using ZettelKasten.Commands;
using ZettelKasten.Middleware;
using ZettelKasten.Models.DTO;
using ZettelKasten.ORM;
using ZettelKasten.Queries;
using ZettelKasten.Startup;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
builder.Services.AddNpgsql<ZettelkastenContext>(connectionString);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation($"ConnectionString={connectionString}");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.MapNotesEndpoints();
app.MapUsersEndpoints();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
