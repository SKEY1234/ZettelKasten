using MediatR;
using ZettelKasten.Models.API;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.Queries;

public record GetAllNotesByUserQuery(Guid? UserId) : IRequest<Result<Note[]>>
{
}
