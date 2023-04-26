using DataAccessLayer.Concrete;
using MDS_Tour.CQRS.Queries.GuideQueries;
using MDS_Tour.CQRS.Results.GuideResults;
using MediatR;

namespace MDS_Tour.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Guidess.FindAsync(request.id);
            return new GetGuideByIdQueryResult
            {
                GuideId = data.GuideId,
                Description = data.Description,
                GuideName = data.GuideName
            };
        }
    }
}
