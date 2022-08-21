using Packt.Shared;

namespace Aeropuerto.WebApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> CreateAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetAsync(int id);
        Task<Usuario?> UpdateAsync(int id, Usuario usuario);
        Task<bool?> DeleteAsync(int id);
    }
}
