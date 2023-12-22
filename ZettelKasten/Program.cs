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

#if !DEBUG
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ZettelkastenContext>();

    dbContext.Database.Migrate();
}
#endif
app.Run();
