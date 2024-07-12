using ApiVuelos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiVuelos.Repository
{
    public class VueloRepository : IRepository<Vuelo>
    {
        private readonly VuelosDbContext _context;

        public VueloRepository(VuelosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vuelo>> Get() =>
            await _context.Vuelos.ToListAsync();

        public async Task<Vuelo> GetById(int id) =>
            await _context.Vuelos.FindAsync(id);

        public async Task Add(Vuelo vuelo) =>
            await _context.Vuelos.AddAsync(vuelo);

        public void Update(Vuelo vuelo)
        {
            _context.Vuelos.Attach(vuelo);
            _context.Vuelos.Entry(vuelo).State = EntityState.Modified;
        }

        public void Delete(Vuelo vuelo)
        {
            _context.Vuelos.Remove(vuelo);
        }
        
        public async Task Save() =>
            await _context.SaveChangesAsync();

    }
}
