namespace MDS_Tour.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
