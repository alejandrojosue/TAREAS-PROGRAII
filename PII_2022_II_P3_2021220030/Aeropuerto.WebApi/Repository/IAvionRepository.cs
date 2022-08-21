using Packt.Shared;

namespace Aeropuerto.WebApi.Repository
{
    public interface IAvionRepository
    {
        Task<Avione?> CreateAsync(Avione avion);
        Task<IEnumerable<Avione>> GetAllAsync();
        Task<Avione?> GetAsync(int id);
        Task<Avione?> UpdateAsync(int id, Avione avion);
        Task<bool?> DeleteAsync(int id);
    }
}
