using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Startup;

public static class TagsEndpointsExtension
{
    public static void MapTagsEndpoints(this WebApplication app)
    {
        app.MapPost("/tags", async (Tag tag, IMediator _mediator, CancellationToken cancellationToken) =>
        {
            Result<Unit> result = await _mediator.Send(new CreateTagCommand(tag), cancellationToken);
        })
        .WithName("CreateTag")
        .WithOpenApi();
    }
}
