using MediatR;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record DeleteUserCommand(Guid? UserId) : IRequest<Result<Unit>>
{
}
