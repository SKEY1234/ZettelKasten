using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetUserByLoginHandler : IRequestHandler<GetUserByLoginQuery, Result<User>>
{
    private readonly ZettelkastenContext _context;

    public GetUserByLoginHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<User>> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
    {
        User? user = await _context.Users.Where(u => u.Login == request.Login).FirstOrDefaultAsync();

        if (user is null)
            return Result<User>.Failure($"Не найден пользователь с логином {request.Login}");

        return Result<User>.Success(user);
    }
}
