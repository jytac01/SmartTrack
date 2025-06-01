using Microsoft.AspNetCore.Identity;

namespace SmartTrack.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
