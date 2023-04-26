using MediatR;

namespace MDS_Tour.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand : IRequest
    {
        public string? GuideName { get; set; }
        public string? Description { get; set; }
    }
}
