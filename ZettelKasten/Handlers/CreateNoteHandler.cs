using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;

    public CreateNoteHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        await _context.Notes.AddAsync(request.Note, cancellationToken);

        await _context.SaveChangesAsync();

        return Result<Unit>.Success(Unit.Value);
    }
}
