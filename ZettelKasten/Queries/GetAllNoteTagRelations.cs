using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Queries;

public record GetAllNoteTagRelationsQuery() : IRequest<Result<NoteTagRelation[]>>
{
}
