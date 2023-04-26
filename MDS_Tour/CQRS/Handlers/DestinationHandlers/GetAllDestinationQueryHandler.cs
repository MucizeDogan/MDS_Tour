using DataAccessLayer.Concrete;
using MDS_Tour.CQRS.Queries.DestinationQueries;
using MDS_Tour.CQRS.Results.DestinationResults;
using Microsoft.EntityFrameworkCore;

namespace MDS_Tour.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle()     //MEdiator kullandığımızda ilgili interfaceden miras alındığında burada oluşan CRUD işleminin gerçekleşeceği metoda default                                                             olarak Handle ismini vereceğinden dolayı biz de Handler ismini verdik.  
        {
            var data = _context.Destinations.Select(x => new GetAllDestinationQueryResult    // Destinationdan her şeyi getirmek istemedsiğim için select yaptım.
            {                                                                              // x=>new GetAllDestinationQueryResult u newledim çünkü orada tutulan propertylere atama                                                                                        yapacağım. boşken CTRL+boşluk yaptığımda zaten onun propları geliyor.    
                id = x.DestinationId,                              //Örneğin id ye atama yapacağız bu nereden gelen id olacak x den çünkü x destination sınıfının bütün proplarını tutuyor.
                capacity = x.Capacity,
                city = x.City,
                DayNight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();
            return data;  
        }
    }
}
