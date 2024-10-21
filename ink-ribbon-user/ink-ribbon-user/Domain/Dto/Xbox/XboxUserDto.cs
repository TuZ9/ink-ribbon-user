namespace ink_ribbon_user.Domain.Dto.Xbox
{
    public class ProfileUser
    {
        public string id { get; set; }
        public string hostId { get; set; }
        public List<Setting> settings { get; set; }
        public bool isSponsoredUser { get; set; }
    }

    public class XboxUserDto
    {
        public List<ProfileUser> profileUsers { get; set; }
    }

    public class Setting
    {
        public string id { get; set; }
        public string value { get; set; }
    }


}
