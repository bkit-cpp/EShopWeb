using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
