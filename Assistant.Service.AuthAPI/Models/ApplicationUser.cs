using Microsoft.AspNetCore.Identity;

namespace Assistant.Service.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
