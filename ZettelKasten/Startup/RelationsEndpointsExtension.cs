using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Startup;

public static class RelationsEndpointsExtension
{
    public static RouteGroupBuilder RelationsGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/CreateNoteRelation", async ([FromBody] NoteRelation relation, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateNoteRelationCommand(relation), cancellationToken);
            return result;
        });

        group.MapDelete("/DeleteNoteRelation", async ([FromQuery] Guid? relationId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteNoteRelationCommand(relationId), cancellationToken);
            return result;
        });

        group.MapPost("/CreateNoteTagRelation", async ([FromBody] NoteTagRelation relation, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateNoteTagRelationCommand(relation), cancellationToken);
            return result;
        });

        group.MapDelete("/DeleteNoteTagRelation", async ([FromQuery] Guid? relationId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteNoteTagRelationCommand(relationId), cancellationToken);
            return result;
        });

        return group;
    }
}
