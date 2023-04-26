namespace MDS_Tour.CQRS.Results.DestinationResults
{
    public class GetDestinationByIdQueryResult
    {
        // burası bizim id ye göre getirdiğimiz verinin güncellemek istediğimiz alanlar olsun.

        public int destinationid { get; set; }             
        public string city { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
