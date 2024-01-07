using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, Result<Guid>>
{
    private readonly ZettelkastenContext _context;

    public CreateNoteHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        await _context.Notes.AddAsync(request.Note, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(request.Note.NoteId);
    }
}
