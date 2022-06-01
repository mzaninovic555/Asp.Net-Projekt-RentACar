using System.ComponentModel.DataAnnotations;

namespace RentACar.Model
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<Car> Cars{ get; set; }
    }
}
