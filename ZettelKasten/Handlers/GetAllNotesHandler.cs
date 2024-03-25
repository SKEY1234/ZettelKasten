using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetAllNotesHandler : IRequestHandler<GetAllNotesQuery, Result<Note[]>>
{
    private readonly ZettelkastenContext _context;

    public GetAllNotesHandler(ZettelkastenContext context)
    {
        _context = context;
    }

    public async Task<Result<Note[]>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
    {
        Note[] notes = await _context.Notes.ToArrayAsync(cancellationToken);

        return Result<Note[]>.Success(notes);
    }
}
