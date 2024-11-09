using ViMusic.Domain.Entities;

namespace ViMusic.Application.Common.Models
{
    public static class Users
    {
        public static User SystemUser = new User
        {
            Username = "System",
            Email = "system@viqub.com",
        };
    }
}
