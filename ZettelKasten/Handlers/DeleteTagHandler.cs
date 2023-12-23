using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public DeleteTagHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        await _context.Tags.Where(x => x.TagId == request.TagId).ExecuteDeleteAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}
