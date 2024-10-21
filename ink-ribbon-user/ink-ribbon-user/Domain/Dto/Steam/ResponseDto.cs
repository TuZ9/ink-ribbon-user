namespace ink_ribbon_user.Domain.Dto.Steam
{
    public class Response
    {
        public List<Player>? players { get; set; }

        public string? steamid { get; set; }

        public int? success { get; set; }
    }
}