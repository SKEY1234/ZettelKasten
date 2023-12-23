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
        await _context.Notes.Where(x => x.NoteId == request.Note.NoteId)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Title, request.Note.Title)
                .SetProperty(p => p.Content, request.Note.Content), 
                cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
