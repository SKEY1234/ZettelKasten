using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Startup;

public static class NoteRelationsEndpointsExtension
{
    public static RouteGroupBuilder NoteRelationsGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/Create", async ([FromBody] NoteRelation relation, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateNoteRelationCommand(relation), cancellationToken);
            return result;
        });

        group.MapDelete("/Delete", async ([FromQuery] Guid? relationId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteNoteRelationCommand(relationId), cancellationToken);
            return result;
        });

        return group;
    }
}
