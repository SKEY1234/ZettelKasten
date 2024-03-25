using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public UpdateTagHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        Tag? existingTag = await _context.Tags.FirstOrDefaultAsync(x => x.TagId == request.Tag.TagId, cancellationToken);

        if (existingTag is null)
            return Result<Unit>.Failure($"Не найден тэг с Id {request.Tag.TagId}");

        existingTag.Name = request.Tag.Name;
        existingTag.Color = request.Tag.Color;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
