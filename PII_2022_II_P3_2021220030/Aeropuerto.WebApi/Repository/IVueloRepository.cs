using Packt.Shared;

namespace Aeropuerto.WebApi.Repository
{
    public interface IVueloRepository
    {
        Task<Vuelo?> CreateAsync(Vuelo vuelo);
        Task<IEnumerable<Vuelo>> GetAllAsync();
        Task<Vuelo?> GetAsync(int id);
        Task<Vuelo?> UpdateAsync(int id, Vuelo vuelo);
        Task<bool?> DeleteAsync(int id);
    }
}
