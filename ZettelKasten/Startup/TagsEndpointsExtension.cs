using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.Queries;

namespace ZettelKasten.Startup;

public static class TagsEndpointsExtension
{
    public static RouteGroupBuilder TagsGroup(this RouteGroupBuilder group)
    {
        group.MapGet("/GetAll", async (IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Tag[]> result = await _mediator.Send(new GetAllTagsQuery(), cancellationToken);

            return result;
        });

        group.MapPost("/Create", async ([FromBody] Tag tag, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateTagCommand(tag), cancellationToken);

            return result;
        });

        group.MapPut("/Update", async ([FromBody] Tag tag, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new UpdateTagCommand(tag), cancellationToken);

            return result;
        });

        group.MapDelete("/Delete", async ([FromQuery] Guid? tagId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteTagCommand(tagId), cancellationToken);

            return result;
        });

        return group;
    }
}
