using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    public class Store
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        [MinLength(3, ErrorMessage = "Name has to be atleast 3 characters.")]
        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(128)]
        public string Email { get; set; }
        public TimeSpan OpenFrom { get; set; }
        public TimeSpan OpenTo { get; set; }

        [ForeignKey(nameof(City))]
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
