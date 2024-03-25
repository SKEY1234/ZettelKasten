using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record CreateTagCommand(Tag Tag) : IRequest<Result<Unit>>
{
}
