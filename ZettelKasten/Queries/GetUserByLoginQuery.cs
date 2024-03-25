using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Queries;

public record GetUserByLoginQuery(string? Login) : IRequest<Result<User>>
{
}
