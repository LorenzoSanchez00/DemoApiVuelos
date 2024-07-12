using Microsoft.EntityFrameworkCore;

namespace ApiVuelos.Models
{
    public class VuelosDbContext : DbContext
    {
        public VuelosDbContext(DbContextOptions<VuelosDbContext> options) :base(options) { }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Aerolinea> Aerolineas { get; set; }
        

    }
}
