using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class NotesEndpointsExtension
{
    public static void MapNotesEndpoints(this WebApplication app)
    {
        app.MapGet("/notes", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            var notes = await _mediator.Send(new GetNotesQuery(), cancellationToken);
            return notes;
        })
        .WithName("GetNotes")
        .WithOpenApi();

        app.MapPost("/notes", async (Note note, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new CreateNoteCommand(note), cancellationToken);
            return result;
        })
        .WithName("CreateNote")
        .WithOpenApi();
    }
}
