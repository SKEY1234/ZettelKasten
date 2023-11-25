using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Commands;

public record CreateUserCommand(User User) : IRequest<Result<Unit>>
{
}
