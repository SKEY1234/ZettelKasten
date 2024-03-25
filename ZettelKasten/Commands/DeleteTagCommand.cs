using MediatR;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record DeleteTagCommand(Guid? TagId) : IRequest<Result<Unit>>
{
}
