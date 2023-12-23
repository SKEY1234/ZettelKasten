using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public UpdateNoteHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        Note? existingNote = await _context.Notes.FirstOrDefaultAsync(x => x.NoteId == request.Note.NoteId, cancellationToken);

        if (existingNote is null)
            return Result<Unit>.Failure($"Не найден тэг с Id {request.Note.NoteId}");

        if (!string.IsNullOrWhiteSpace(request.Note.Title))
            existingNote.Title = request.Note.Title;

        if (!string.IsNullOrWhiteSpace(request.Note.Content))
            existingNote.Content = request.Note.Content;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
