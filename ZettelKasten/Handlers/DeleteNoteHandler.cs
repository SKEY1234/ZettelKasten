using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public DeleteNoteHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        await _context.Notes.Where(x => x.NoteId == request.NoteId).ExecuteDeleteAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}
