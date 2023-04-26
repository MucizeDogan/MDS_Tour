using DataAccessLayer.Concrete;
using MDS_Tour.CQRS.Queries.GuideQueries;
using MDS_Tour.CQRS.Results.GuideResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MDS_Tour.CQRS.Handlers.GuideHandlers
{   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // MEDIATR KUTUPHANESİNİ KULLANIYORUZ BURADA YANİ CQRS DE NORMALDE BURADA HANDLE METODUNU KENDİMİZ YAZIYODUK MEDIATR İLE HANDLE METODUNU MEDİATR YAZACAK.

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // : IRequestHandler<İstek kaynağı,Cevap kaynağı> + implement ettiğinde handle metodun hazır.
    
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guidess.Select(x => new GetAllGuideQueryResult
            {
                Description = x.Description,
                GuideId = x.GuideId,
                GuideName = x.GuideName

            }).AsNoTracking().ToListAsync();
        }
    }
}
