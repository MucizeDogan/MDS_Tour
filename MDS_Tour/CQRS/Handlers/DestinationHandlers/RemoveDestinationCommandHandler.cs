using DataAccessLayer.Concrete;
using MDS_Tour.CQRS.Commands.DestinationCommands;

namespace MDS_Tour.CQRS.Handlers.DestinationHandlers
{
    
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var data = _context.Destinations.Find(command.id);
            _context.Destinations.Remove(data);
            _context.SaveChanges();
        }
    }
}
