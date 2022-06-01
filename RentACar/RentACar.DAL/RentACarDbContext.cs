using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Model;

namespace RentACar.DAL
{
    public class RentACarDbContext : IdentityDbContext<AppUser>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options) : base(options){ }
    }
}
