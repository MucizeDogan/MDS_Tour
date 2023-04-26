using DataAccessLayer.Concrete;
using MDS_Tour.CQRS.Commands.DestinationCommands;

namespace MDS_Tour.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var data = _context.Destinations.Find(command.destinationid);
            data.City = command.city;
            data.Capacity = command.Capacity;
            data.DayNight = command.DayNight;
            data.Price = command.Price;
            _context.Destinations.Update(data);
            _context.SaveChanges();
        }
    }
}
