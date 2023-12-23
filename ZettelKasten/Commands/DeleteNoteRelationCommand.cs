using MediatR;
using ZettelKasten.Models.API;

namespace ZettelKasten.Commands;

public record DeleteNoteRelationCommand(Guid? RelationId) : IRequest<Result<Unit>>
{
}
