namespace MDS_Tour.CQRS.Results.GuideResults
{
    public class GetGuideByIdQueryResult
    {
        public int GuideId { get; set; }
        public string? GuideName { get; set; }
        public string? Description { get; set; }
    }
}
