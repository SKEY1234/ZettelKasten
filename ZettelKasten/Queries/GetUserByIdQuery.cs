using MediatR;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;

namespace ZettelKasten.Queries;

public record GetUserByIdQuery(Guid? UserId) : IRequest<Result<User>>
{
}
