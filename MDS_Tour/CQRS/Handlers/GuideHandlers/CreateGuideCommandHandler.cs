using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MDS_Tour.CQRS.Commands.GuideCommands;
using MediatR;

namespace MDS_Tour.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)// buradaki <Unit> ifadesi void (yani geriye bir şey dönmüyoru) ifade ediyor.
        {
            _context.Guidess.Add(new Guides
            {
                GuideName = request.GuideName,
                Description = request.Description,
                Status = true
            }) ;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
