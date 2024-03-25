using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record CreateNoteTagRelationCommand(NoteTagRelation NoteTagRelation) : IRequest<Result<Unit>>
{
}
