using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ZettelKasten.Configurations;
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
builder.Services.AddOptions<JwtConfig>()
    .Bind(builder.Configuration.GetSection(nameof(JwtConfig)))
    .ValidateDataAnnotations();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ZettelkastenContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(nameof(JwtConfig)).Value!);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = false
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

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
