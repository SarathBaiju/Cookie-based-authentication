namespace CookieAuthentication.DataAccess.Entities
{
    public class UserRole:Base
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
