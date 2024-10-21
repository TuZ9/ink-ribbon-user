namespace ink_ribbon_user.Domain.Dto.Xbox
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Achievement
    {
        public int currentAchievements { get; set; }
        public int totalAchievements { get; set; }
        public int currentGamerscore { get; set; }
        public int totalGamerscore { get; set; }
        public int progressPercentage { get; set; }
        public int sourceVersion { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string type { get; set; }
        public string caption { get; set; }
    }

    public class AchievementDto
    {
        public string xuid { get; set; }
        public List<Title> titles { get; set; }
    }

    public class Title
    {
        public string titleId { get; set; }
        public string pfn { get; set; }
        public string bingId { get; set; }
        public string serviceConfigId { get; set; }
        public object windowsPhoneProductId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<string> devices { get; set; }
        public string displayImage { get; set; }
        public string mediaItemType { get; set; }
        public string modernTitleId { get; set; }
        public bool isBundle { get; set; }
        public Achievement achievement { get; set; }
        public object stats { get; set; }
        public object gamePass { get; set; }
        public List<Image> images { get; set; }
        public TitleHistory titleHistory { get; set; }
        public object titleRecord { get; set; }
        public object detail { get; set; }
        public object friendsWhoPlayed { get; set; }
        public object alternateTitleIds { get; set; }
        public object contentBoards { get; set; }
        public string xboxLiveTier { get; set; }
        public bool isStreamable { get; set; }
    }

    public class TitleHistory
    {
        public DateTime lastTimePlayed { get; set; }
        public bool visible { get; set; }
        public bool canHide { get; set; }
    }


}
