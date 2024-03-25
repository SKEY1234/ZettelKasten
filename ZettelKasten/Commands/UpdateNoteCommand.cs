using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record UpdateNoteCommand(Note Note) : IRequest<Result<Unit>>
{
}
