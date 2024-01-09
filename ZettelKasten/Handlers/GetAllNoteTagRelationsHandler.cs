using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetAllNoteTagRelationsHandler : IRequestHandler<GetAllNoteTagRelationsQuery, Result<NoteTagRelation[]>>
{
    private readonly ZettelkastenContext _context;

    public GetAllNoteTagRelationsHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<NoteTagRelation[]>> Handle(GetAllNoteTagRelationsQuery request, CancellationToken cancellationToken)
    {
        NoteTagRelation[] relations = await _context.NoteTagRelations.ToArrayAsync(cancellationToken);

        return Result<NoteTagRelation[]>.Success(relations);
    }
}
