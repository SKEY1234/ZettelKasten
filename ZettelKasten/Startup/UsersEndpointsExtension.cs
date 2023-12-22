using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class UsersEndpointsExtension
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/users{login}", async ([FromQuery] string? login, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<User> user = await _mediator.Send(new GetUserByLoginQuery(login), cancellationToken);
            return user;
        })
        .WithName("GetUserByLogin")
        .WithOpenApi();

        app.MapGet("/users", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<User[]> user = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
            return user;
        })
        .WithName("GetUsers")
        .WithOpenApi();

        app.MapPost("/users", async ([FromBody] User user, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new CreateUserCommand(user), cancellationToken);
            return result;
        })
        .WithName("CreateUser")
        .WithOpenApi();
    }
}
