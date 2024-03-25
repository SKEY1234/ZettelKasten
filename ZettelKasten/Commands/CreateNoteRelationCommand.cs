using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record CreateNoteRelationCommand(NoteRelation NoteRelation) : IRequest<Result<Unit>>
{
}
