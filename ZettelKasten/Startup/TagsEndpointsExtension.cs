using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Startup;

public static class TagsEndpointsExtension
{
    public static RouteGroupBuilder TagsGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/Create", async (Tag tag, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateTagCommand(tag), cancellationToken);

            return result;
        });

        group.MapPut("/Update", async (Tag tag, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new UpdateTagCommand(tag), cancellationToken);

            return result;
        });

        group.MapDelete("/Delete", async (Guid? tagId, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new DeleteTagCommand(tagId), cancellationToken);

            return result;
        });

        return group;
    }
}
