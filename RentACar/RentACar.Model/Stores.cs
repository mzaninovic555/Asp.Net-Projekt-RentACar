﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    public class Stores
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public TimeOnly OpenFrom { get; set; }
        public TimeOnly OpenTo { get; set; }
    }
}