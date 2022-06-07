using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        [Required]
        public string Model { get; set; }

        [StringLength(255)]
        [Required]
        public string PictureURL { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "Number of seats has to be between 1 and 8.")]
        public int SeatCount { get; set; }

        [Required]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Year has to be 4 digits.")]
        [Range(2000, 2022, ErrorMessage = "Year has to be between 2000 and 2022")]
        public int ProductionYear { get; set; }

        [Required]
        public bool IsManual { get; set; }

        [Required]
        public bool HasBluetooth { get; set; }

        [Required]
        public bool HasParkingSensors { get; set; }

        [Required]
        public bool IsElectric { get; set; }

        [Required]
        public bool HasGps { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandID { get; set; }
        public virtual Brand? Brand { get; set; }
    }
}
