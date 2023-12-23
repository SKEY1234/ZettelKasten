using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Commands;

public record CreateNoteTagRelationCommand(NoteTagRelation NoteTagRelation) : IRequest<Result<Unit>>
{
}
