using MediatR;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record DeleteNoteRelationCommand(Guid? RelationId) : IRequest<Result<Unit>>
{
}
