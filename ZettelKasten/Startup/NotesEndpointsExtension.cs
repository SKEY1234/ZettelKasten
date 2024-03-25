using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class NotesEndpointsExtension
{
    public static RouteGroupBuilder NotesGroup(this RouteGroupBuilder group)
    {
        group.MapGet("/GetAll", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Note[]> notes = await _mediator.Send(new GetAllNotesQuery(), cancellationToken);
            return notes;
        });

        group.MapGet("/GetAllByUser", async ([FromQuery] Guid? userId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Note[]> notes = await _mediator.Send(new GetAllNotesByUserQuery(userId), cancellationToken);
            return notes;
        });

        group.MapPost("/Create", async ([FromBody] Note note, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Guid> result = await _mediator.Send(new CreateNoteCommand(note), cancellationToken);
            return result;
        });

        group.MapPut("/Update", async ([FromBody] Note note, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new UpdateNoteCommand(note), cancellationToken);
            return result;
        });

        group.MapDelete("/Delete", async ([FromQuery] Guid? noteId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteNoteCommand(noteId), cancellationToken);
            return result;
        });

        return group;
    }
}
