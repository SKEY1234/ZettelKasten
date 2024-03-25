using MediatR;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record DeleteNoteTagRelationCommand(Guid? RelationId) : IRequest<Result<Unit>>
{
}
