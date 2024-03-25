using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class DeleteNoteTagRelationHandler : IRequestHandler<DeleteNoteTagRelationCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public DeleteNoteTagRelationHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(DeleteNoteTagRelationCommand request, CancellationToken cancellationToken)
    {
        await _context.NoteTagRelations.Where(x => x.RelationId == request.RelationId)
            .ExecuteDeleteAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}
