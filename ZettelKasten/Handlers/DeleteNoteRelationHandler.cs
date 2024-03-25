using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Commands;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class DeleteNoteRelationHandler : IRequestHandler<DeleteNoteRelationCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public DeleteNoteRelationHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(DeleteNoteRelationCommand request, CancellationToken cancellationToken)
    {
        await _context.NoteRelations.Where(x => x.RelationId == request.RelationId)
            .ExecuteDeleteAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}
