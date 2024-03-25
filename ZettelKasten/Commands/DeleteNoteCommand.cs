using MediatR;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record DeleteNoteCommand(Guid? NoteId) : IRequest<Result<Unit>>
{
}
