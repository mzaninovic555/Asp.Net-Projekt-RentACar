using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Model
{
    public class AppUser : IdentityUser
    {
        [StringLength(255)]
        public string OIB { get; set; }
    }
}
