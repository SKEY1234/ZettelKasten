using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<User>>
{
    private readonly ZettelkastenContext _context;
    public GetUserByIdHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _context.Users.Where(u => u.UserId == request.UserId).FirstOrDefaultAsync();

        if (user is null)
            return Result<User>.Failure($"Не найден пользователь с Id {request.UserId}");

        return Result<User>.Success(user);
    }
}
