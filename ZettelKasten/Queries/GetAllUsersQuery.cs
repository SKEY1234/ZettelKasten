using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Queries;

public record GetAllUsersQuery() : IRequest<Result<User[]>>
{
}
