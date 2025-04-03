namespace ink_ribbon_user.Domain.Dto
{
    public class GamesDto
    {
        public AppList applist { get; set; }
    }
    public class AppList
    {
        public IEnumerable<Apps> apps { get; set; }
    }
    public class Apps
    {
        public int appid { get; set; }
        public string name { get; set; }
    }
}
