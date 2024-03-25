using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record CreateNoteCommand(Note Note) : IRequest<Result<Guid>>
{
}
