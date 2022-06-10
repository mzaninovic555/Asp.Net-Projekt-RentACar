using System.ComponentModel.DataAnnotations;

namespace RentACar.Model
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be atleast 3 characters.")]
        public string Name { get; set; }
        public virtual ICollection<Car>? Cars{ get; set; }
    }
}
