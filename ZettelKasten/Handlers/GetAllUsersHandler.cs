using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<User[]>>
{
    private readonly ZettelkastenContext _context;
    public GetAllUsersHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<User[]>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        User[] users = await _context.Users.ToArrayAsync(cancellationToken);

        return Result<User[]>.Success(users);
    }
}
