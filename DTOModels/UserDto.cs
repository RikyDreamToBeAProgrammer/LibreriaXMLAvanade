

namespace DTOModels
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DtoRole Role { get; set; }
    }
    public enum DtoRole
    {
        User = 1,
        Admin = 2
    }
}
