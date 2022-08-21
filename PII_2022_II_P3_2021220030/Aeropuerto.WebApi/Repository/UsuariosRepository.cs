using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Concurrent;
namespace Aeropuerto.WebApi.Repository
{
    public class UsuariosRepository:IUsuarioRepository
    {
        private static ConcurrentDictionary<int, Usuario>? UsuarioCache;
        private aeropuertoDBContext db;

        public UsuariosRepository(aeropuertoDBContext contextoInyectado)
        {
            this.db = contextoInyectado;
            if (UsuarioCache is null)
            {
                UsuarioCache = new ConcurrentDictionary<int, Usuario>(
                    db.Usuarios.Include(u=>u.IdCargoNavigation).ToDictionary(c => c.IdUsuario));
            }
        }

        public async Task<Usuario?> CreateAsync(Usuario usuario)
        {
            EntityEntry<Usuario> adicionado = await db.Usuarios.AddAsync(usuario);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (UsuarioCache is null) return usuario;
                return UsuarioCache.AddOrUpdate(usuario.IdUsuario, usuario, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Usuario UpdateCache(int id, Usuario avion)
        {
            Usuario? anterior;
            if (UsuarioCache is not null)
            {
                if (UsuarioCache.TryGetValue(id, out anterior))
                {
                    if (UsuarioCache.TryUpdate(id, avion, anterior))
                    {
                        return avion;
                    }
                }
            }
            return null!;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Usuario? usuario = db.Usuarios.Find(id);
            if (usuario is null) return null!;
            db.Usuarios.Remove(usuario);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (UsuarioCache is null) return null;
                return UsuarioCache.TryRemove(id, out usuario);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            UsuarioCache = new ConcurrentDictionary<int, Usuario>(
                    db!.Usuarios.Include(u => u.IdCargoNavigation).ToDictionary(c => c.IdUsuario));
            return Task.FromResult(UsuarioCache is null ? Enumerable.Empty<Usuario>() :
                UsuarioCache.Values);
        }

        public Task<Usuario?> GetAsync(int id)
        {
            if (UsuarioCache is null) return null!;
            UsuarioCache!.TryGetValue(id, out Usuario? avion);
            return Task.FromResult(avion);
        }

        public async Task<Usuario?> UpdateAsync(int id, Usuario avion)
        {
            db.Usuarios.Update(avion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                return UpdateCache(id, avion);
            }
            return null;
        }
    }
}
