namespace MDS_Tour.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int id { get; set; }
        public string city { get; set; }
        public string DayNight { get; set; }
        public double price{ get; set; }
        public int capacity { get; set; }
    }
}
