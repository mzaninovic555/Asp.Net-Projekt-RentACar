using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        [StringLength(255)]
        public string PictureURL { get; set; }
        public int SeatCount { get; set; }
        public int ProductionYear { get; set; }
        public bool IsManual { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasParkingSensors { get; set; }
        public bool IsElectric { get; set; }
        public bool HasGps { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
