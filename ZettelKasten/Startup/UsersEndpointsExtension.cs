using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class UsersEndpointsExtension
{
    public static RouteGroupBuilder UsersGroup(this RouteGroupBuilder group)
    {
        group.MapGet("/GetById", async ([FromQuery] Guid? userId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<User> user = await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
            return user;
        });

        group.MapGet("/GetByLogin", async ([FromQuery] string? login, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<User> user = await _mediator.Send(new GetUserByLoginQuery(login), cancellationToken);
            return user;
        });

        group.MapGet("/GetAll", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<User[]> user = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
            return user;
        });

        group.MapPost("/Create", async ([FromBody] User user, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateUserCommand(user), cancellationToken);
            return result;
        });

        group.MapDelete("/Delete", async ([FromQuery] Guid? userId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteUserCommand(user), cancellationToken);
            return result;
        });

        return group;
    }
}
