namespace SignalRApiForSql.DAL
{
    public enum ECity
    {
        İstanbul = 1,
        Berlin = 2,
        Ankara = 3,
        Londra = 4,
        Bursa = 5

    }
    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
