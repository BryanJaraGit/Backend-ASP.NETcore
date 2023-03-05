namespace Backend_ASP.NETcore.Models.Repository
{
    public interface IProspectoRepository
    {
        Task<List<Prospecto>> GetListProspectos();
        Task<Prospecto> GetProspecto(int id);
        Task DeleteProspecto(Prospecto prospecto);
        Task<Prospecto> AddProspecto(Prospecto prospecto);
        Task UpdateProspecto(Prospecto prospecto);
    }
}
