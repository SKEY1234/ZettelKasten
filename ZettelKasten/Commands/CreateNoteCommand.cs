using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Commands;

public record CreateNoteCommand(Note Note) : IRequest<Result<Unit>>
{
}
