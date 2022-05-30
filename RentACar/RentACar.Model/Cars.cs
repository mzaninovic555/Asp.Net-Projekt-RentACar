using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    public class Cars
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int SeatCount { get; set; }
        public int ProductionYear { get; set; }
        public bool IsManual { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasParkingSensors { get; set; }
        public bool IsElectric { get; set; }
        public bool HasGps { get; set; }
    }
}
