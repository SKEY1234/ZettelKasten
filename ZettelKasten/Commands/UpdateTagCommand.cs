using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Commands;

public record UpdateTagCommand(Tag Tag) : IRequest<Result<Unit>>
{
}
