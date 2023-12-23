using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class CreateNoteRelationHandler : IRequestHandler<CreateNoteRelationCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public CreateNoteRelationHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(CreateNoteRelationCommand request, CancellationToken cancellationToken)
    {
        await _context.NoteRelations.AddAsync(request.NoteRelation, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
