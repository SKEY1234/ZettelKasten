using MediatR;
using ZettelKasten.Models.API;

namespace ZettelKasten.Commands;

public record DeleteNoteCommand(Guid? NoteId) : IRequest<Result<Unit>>
{
}
