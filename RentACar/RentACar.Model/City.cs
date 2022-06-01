using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    public class City
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public int PostalCode { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
