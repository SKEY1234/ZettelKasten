using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;

    public CreateUserHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(request.User, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
