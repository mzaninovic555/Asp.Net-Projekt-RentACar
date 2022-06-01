using Microsoft.AspNetCore.Identity;

namespace RentACar.Model
{
    public class AppUser : IdentityUser
    {
        public string OIB { get; set; }
    }
}
