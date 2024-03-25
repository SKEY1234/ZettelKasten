using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Commands;

public record CreateUserCommand(User User) : IRequest<Result<Unit>>
{
}
