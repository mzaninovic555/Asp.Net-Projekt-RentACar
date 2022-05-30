using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class RentACarDbContext : IdentityDbContext<AppUser>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options) : base(options){ }
    }
}
