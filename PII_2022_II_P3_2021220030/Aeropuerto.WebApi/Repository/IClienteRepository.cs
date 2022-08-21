using Packt.Shared;

namespace Aeropuerto.WebApi.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente?> CreateAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetAsync(int id);
        Task<Cliente?> UpdateAsync(int id, Cliente cliente);
        Task<bool?> DeleteAsync(int id);
    }
}
