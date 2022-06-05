using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        [RegularExpression("[0-9]{11}")]
        [StringLength(255)]
        public string OIB { get; set; }
    }
}
