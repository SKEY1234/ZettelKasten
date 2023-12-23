using MediatR;
using ZettelKasten.Models.API;

namespace ZettelKasten.Commands;

public record DeleteTagCommand(Guid? TagId) : IRequest<Result<Unit>>
{
}
