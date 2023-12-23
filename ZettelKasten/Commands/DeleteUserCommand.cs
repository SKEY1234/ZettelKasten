using MediatR;
using ZettelKasten.Models.API;

namespace ZettelKasten.Commands;

public record DeleteUserCommand(Guid? UserId) : IRequest<Result<Unit>>
{
}
