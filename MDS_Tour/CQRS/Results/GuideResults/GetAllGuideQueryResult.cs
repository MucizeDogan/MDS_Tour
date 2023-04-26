namespace MDS_Tour.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {
        public int GuideId { get; set; }
        public string? GuideName { get; set; }
        public string? Description { get; set; }
    }
}
