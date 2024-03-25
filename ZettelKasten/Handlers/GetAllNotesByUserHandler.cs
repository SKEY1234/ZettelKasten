using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetAllNotesByUserHandler : IRequestHandler<GetAllNotesByUserQuery, Result<Note[]>>
{
    private readonly ZettelkastenContext _context;
    public GetAllNotesByUserHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Note[]>> Handle(GetAllNotesByUserQuery request, CancellationToken cancellationToken)
    {
        Note[] notes = await _context.Notes.Where(x => x.UserId == request.UserId).ToArrayAsync(cancellationToken);

        return Result<Note[]>.Success(notes);
    }
}
