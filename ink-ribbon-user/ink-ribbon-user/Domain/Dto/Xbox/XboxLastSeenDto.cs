namespace ink_ribbon_user.Domain.Dto.Xbox
{
    public class XboxLastSeenDto
    {
        public required string xuid { get; set; }
        public string? state { get; set; }
        public LastSeen? lastSeen { get; set; }
        public bool cloaked { get; set; }
    }
    public class LastSeen
    {
        public string? deviceType { get; set; }
        public string? titleId { get; set; }
        public string? titleName { get; set; }
        public DateTime? timestamp { get; set; }
    }
}
