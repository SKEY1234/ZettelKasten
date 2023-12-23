using MediatR;
using ZettelKasten.Models.API;

namespace ZettelKasten.Commands;

public record DeleteNoteTagRelationCommand(Guid? RelationId) : IRequest<Result<Unit>>
{
}
