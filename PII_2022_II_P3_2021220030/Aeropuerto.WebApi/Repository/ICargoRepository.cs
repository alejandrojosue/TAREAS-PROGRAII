using Packt.Shared;

namespace Aeropuerto.WebApi.Repository
{
    public interface ICargoRepository
    {
        Task<Cargo?> CreateAsync(Cargo cargo);
        Task<IEnumerable<Cargo>> GetAllAsync();
        Task<Cargo?> GetAsync(int id);
        Task<Cargo?> UpdateAsync(int id, Cargo cargo);
        Task<bool?> DeleteAsync(int id);
    }
}
