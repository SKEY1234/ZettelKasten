using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class CreateTagHandler : IRequestHandler<CreateTagCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public CreateTagHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await _context.Tags.AddAsync(request.Tag, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
