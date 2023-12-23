using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Commands;

public record UpdateNoteCommand(Note Note) : IRequest<Result<Unit>>
{
}
