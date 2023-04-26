using DataAccessLayer.Concrete;
using MDS_Tour.CQRS.Queries.DestinationQueries;
using MDS_Tour.CQRS.Results.DestinationResults;

namespace MDS_Tour.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query) // Parametremizi almak için query nesnesi oluşturduk.
        {
            var data = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                destinationid = data.DestinationId,
                city = data.City,
                DayNight = data.DayNight,
                Price = data.Price
            };
        }
    }
}
