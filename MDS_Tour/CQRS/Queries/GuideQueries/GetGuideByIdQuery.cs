using MDS_Tour.CQRS.Results.GuideResults;
using MediatR;

namespace MDS_Tour.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public GetGuideByIdQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
