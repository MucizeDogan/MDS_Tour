using MDS_Tour.CQRS.Results.GuideResults;
using MediatR;

namespace MDS_Tour.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
