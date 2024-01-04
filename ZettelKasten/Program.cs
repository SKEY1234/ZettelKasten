using Microsoft.EntityFrameworkCore;
using ZettelKasten.Middleware;
using ZettelKasten.ORM;
using ZettelKasten.Startup;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
#if DEBUG
    EnvironmentName = "Development"
#endif
});

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddNpgsql<ZettelkastenContext>(connectionString);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.Logger.LogInformation($"ConnectionString={connectionString}");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

//app.UseHttpsRedirection();

app.MapGroup("/api")
    .ApiGroup()
    .WithOpenApi();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ZettelkastenContext>();

    dbContext.Database.Migrate();
}

app.Run();
