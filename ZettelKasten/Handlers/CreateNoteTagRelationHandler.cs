using MediatR;
using ZettelKasten.Commands;
using ZettelKasten.Models.API;
using ZettelKasten.ORM;

namespace ZettelKasten.Handlers;

public class CreateNoteTagRelationHandler : IRequestHandler<CreateNoteTagRelationCommand, Result<Unit>>
{
    private readonly ZettelkastenContext _context;
    public CreateNoteTagRelationHandler(ZettelkastenContext context)
    {
        _context = context;
    }
    public async Task<Result<Unit>> Handle(CreateNoteTagRelationCommand request, CancellationToken cancellationToken)
    {
        await _context.NoteTagRelations.AddAsync(request.NoteTagRelation, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}