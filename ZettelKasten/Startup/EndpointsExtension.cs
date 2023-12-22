using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class EndpointsExtension
{
    public static void MapNotesEndpoints(this WebApplication app)
    {
        app.MapGet("/notes", async (IMediator _mediator) =>
        {
            var notes = await _mediator.Send(new GetNotesQuery());
            return notes;
        })
        .WithName("GetNotes")
        .WithOpenApi();

        app.MapPost("/notes", async (Note note, IMediator _mediator) =>
        {
            var result = await _mediator.Send(new CreateNoteCommand(note));
            return result;
        })
        .WithName("CreateNote")
        .WithOpenApi();
    }

    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/users{login}", async ([FromQuery] string? login, IMediator _mediator) =>
        {
            Result<User> user = await _mediator.Send(new GetUserByLoginQuery(login));
            return user;
        })
        .WithName("GetUserByLogin")
        .WithOpenApi();

        app.MapGet("/users", async (IMediator _mediator) =>
        {
            Result<User[]> user = await _mediator.Send(new GetAllUsersQuery());
            return user;
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        app.MapPost("/users", async ([FromBody] User user, IMediator _mediator) =>
        {
            var result = await _mediator.Send(new CreateUserCommand(user));
            return result;
        })
        .WithName("CreateUser")
        .WithOpenApi();
    }
}
