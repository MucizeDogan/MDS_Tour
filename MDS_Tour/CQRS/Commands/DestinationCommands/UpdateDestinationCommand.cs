namespace MDS_Tour.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        // burası bizim id ye göre getirdiğimiz verinin güncellemek istediğimiz alanlar olsun.

        public int destinationid { get; set; }
        public string city { get; set; }
        public string DayNight { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
    }
}
