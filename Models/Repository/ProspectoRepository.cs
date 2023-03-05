using Microsoft.EntityFrameworkCore;

namespace Backend_ASP.NETcore.Models.Repository
{
    public class ProspectoRepository: IProspectoRepository
    {
        private readonly AplicationDbContext _context;

        public ProspectoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Prospecto> AddProspecto(Prospecto prospecto)
        {
            _context.Add(prospecto);
            await _context.SaveChangesAsync();

            return prospecto;
        }

        public async Task DeleteProspecto(Prospecto prospecto)
        {
            _context.Prospectos.Remove(prospecto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Prospecto>> GetListProspectos()
        {
            return await _context.Prospectos.ToListAsync();
        }

        public async Task<Prospecto> GetProspecto(int id)
        {
            return await _context.Prospectos.FindAsync(id);
        }

        public async Task UpdateProspecto(Prospecto prospecto)
        {
            var prospectoItem = await _context.Prospectos.FirstOrDefaultAsync(x => x.Id == prospecto.Id);

            if(prospectoItem != null)
            {
                prospectoItem.Nombres = prospecto.Nombres;
                prospectoItem.Apellidos = prospecto.Apellidos;
                prospectoItem.Telefono = prospecto.Telefono;
                prospectoItem.Correo = prospecto.Correo;
                prospectoItem.Direccion = prospecto.Direccion;
                prospectoItem.Servicio = prospecto.Servicio;

                await _context.SaveChangesAsync();
            }
        }
    }
}
