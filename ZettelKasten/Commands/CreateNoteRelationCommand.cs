using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Commands;

public record CreateNoteRelationCommand(NoteRelation NoteRelation) : IRequest<Result<Unit>>
{
}
