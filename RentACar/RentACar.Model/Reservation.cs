using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        public string? UserID { get; set; }
        
        [Required]
        [ReservationDate]
        public DateTime PickupDateTime { get; set; }

        [ForeignKey(nameof(Store))]
        [Required]
        public int StoreID { get; set; }
        public virtual Store? Store { get; set; }

        [ForeignKey(nameof(Car))]
        [Required]
        public int CarID { get; set; }
        public virtual Car? Car { get; set; }
    }

    public class ReservationDate : ValidationAttribute
    {
        private readonly DateTime _date;

        public ReservationDate()
            : base("Date has to be before today.")
        {
            this._date = DateTime.Today;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var validationDate = (DateTime)value;
                if (validationDate.Date > this._date.Date)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Date has to be after today.");
        }
    }
}
