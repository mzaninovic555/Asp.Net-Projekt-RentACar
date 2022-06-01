using System.ComponentModel.DataAnnotations;

namespace RentACar.Model
{
    public class Country
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
