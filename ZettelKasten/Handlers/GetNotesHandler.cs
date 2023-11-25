using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetNotesHandler : IRequestHandler<GetNotesQuery, Result<Note[]>>
{
    private readonly ZettelkastenContext _context;

    public GetNotesHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<Note[]>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        Note[] notes = await _context.Notes.ToArrayAsync(cancellationToken);

        return Result<Note[]>.Success(notes);
    }
}
