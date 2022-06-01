using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public DateTime PickupDateTime { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
    }
}
