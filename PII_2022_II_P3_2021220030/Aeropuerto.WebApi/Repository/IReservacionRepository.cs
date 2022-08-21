using Packt.Shared;

namespace Aeropuerto.WebApi.Repository
{
    public interface IReservacionRepository
    {
        Task<Reservacione?> CreateAsync(Reservacione Reservacione);
        Task<IEnumerable<Reservacione>> GetAllAsync();
        Task<Reservacione?> GetAsync(int id);
        Task<Reservacione?> UpdateAsync(int id, Reservacione Reservacione);
        Task<bool?> DeleteAsync(int id);
    }
}
