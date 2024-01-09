using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class NoteTagRelationsEndpointsExtension
{
    public static RouteGroupBuilder NoteTagRelationsGroup(this RouteGroupBuilder group)
    {
        group.MapGet("/GetAll", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<NoteTagRelation[]> result = await _mediator.Send(new GetAllNoteTagRelationsQuery(), cancellationToken);
            return result;
        });

        group.MapPost("/Create", async ([FromBody] NoteTagRelation relation, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateNoteTagRelationCommand(relation), cancellationToken);
            return result;
        });

        group.MapDelete("/Delete", async ([FromQuery] Guid? relationId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteNoteTagRelationCommand(relationId), cancellationToken);
            return result;
        });

        return group;
    }
}
