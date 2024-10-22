namespace ink_ribbon_user.Domain.Dto.Xbox
{
    public class Detail
    {
        public string? accountTier { get; set; }
        public object? bio { get; set; }
        public bool isVerified { get; set; }
        public object? location { get; set; }
        public object? tenure { get; set; }
        public List<object>? watermarks { get; set; }
        public bool blocked { get; set; }
        public bool mute { get; set; }
        public int followerCount { get; set; }
        public int followingCount { get; set; }
        public bool hasGamePass { get; set; }
    }

    public class Person
    {
        public required string xuid { get; set; }
        public bool isFavorite { get; set; }
        public bool isFollowingCaller { get; set; }
        public bool isFollowedByCaller { get; set; }
        public bool isIdentityShared { get; set; }
        public object? addedDateTimeUtc { get; set; }
        public object? displayName { get; set; }
        public required string realName { get; set; }
        public required string displayPicRaw { get; set; }
        public string? showUserAsAvatar { get; set; }
        public required string gamertag { get; set; }
        public required string gamerScore { get; set; }
        public string? modernGamertagSuffix { get; set; }
        public string? uniqueModernGamertag { get; set; }
        public string? xboxOneRep { get; set; }
        public object? presenceState { get; set; }
        public object? presenceText { get; set; }
        public object? presenceDevices { get; set; }
        public bool isBroadcasting { get; set; }
        public object? isCloaked { get; set; }
        public bool isQuarantined { get; set; }
        public bool isXbox360Gamerpic { get; set; }
        public object? lastSeenDateTimeUtc { get; set; }
        public object? suggestion { get; set; }
        public object? recommendation { get; set; }
        public Search? search { get; set; }
        public object? titleHistory { get; set; }
        public object? multiplayerSummary { get; set; }
        public object? recentPlayer { get; set; }
        public object? follower { get; set; }
        public PreferredColor? preferredColor { get; set; }
        public object? presenceDetails { get; set; }
        public object? titlePresence { get; set; }
        public object? titleSummaries { get; set; }
        public object? presenceTitleIds { get; set; }
        public Detail? detail { get; set; }
        public object? communityManagerTitles { get; set; }
        public object? socialManager { get; set; }
        public object? broadcast { get; set; }
        public object? avatar { get; set; }
        public object? linkedAccounts { get; set; }
        public string? colorTheme { get; set; }
        public string? preferredFlag { get; set; }
        public List<object>? preferredPlatforms { get; set; }
    }

    public class PreferredColor
    {
        public string? primaryColor { get; set; }
        public string? secondaryColor { get; set; }
        public string? tertiaryColor { get; set; }
    }

    public class XboxUserDto
    {
        public List<Person>? people { get; set; }
        public object? recommendationSummary { get; set; }
        public object? friendFinderState { get; set; }
        public object? accountLinkDetails { get; set; }
    }

    public class Search
    {
        public string? Type { get; set; }
        public List<object>? Reasons { get; set; }
    }

}
