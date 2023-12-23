using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public DeleteUserHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _context.Users.Where(x => x.UserId == request.UserId).ExecuteDeleteAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}
