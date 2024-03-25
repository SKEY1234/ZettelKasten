using MediatR;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models.DTO;
using ZettelKasten.Models.Responses;
using ZettelKasten.ORM;
using ZettelKasten.Queries;

namespace ZettelKasten.Handlers;

public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, Result<Tag[]>>
{
    private readonly ZettelkastenContext _context;
    public GetAllTagsHandler(ZettelkastenContext context) => _context = context;

    public async Task<Result<Tag[]>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        Tag[] tags = await _context.Tags.ToArrayAsync(cancellationToken);

        return Result<Tag[]>.Success(tags);
    }
}
