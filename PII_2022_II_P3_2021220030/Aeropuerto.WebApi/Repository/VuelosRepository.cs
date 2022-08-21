using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Concurrent;

namespace Aeropuerto.WebApi.Repository
{
    public class VuelosRepository:IVueloRepository
    {
        private static ConcurrentDictionary<int, Vuelo>? vueloCache;
        private aeropuertoDBContext db;

        public VuelosRepository(aeropuertoDBContext contextoInyectado)
        {
            this.db = contextoInyectado;
            if (vueloCache is null)
            {
                vueloCache = new ConcurrentDictionary<int, Vuelo>(
                    db.Vuelos.Include(v=>v.IdAvionNavigation).Include(v=>v.IdPilotoNavigation).ToDictionary(c => c.IdVuelo));
            }
        }

        public async Task<Vuelo?> CreateAsync(Vuelo vuelo)
        {
            EntityEntry<Vuelo> adicionado = await db.Vuelos.AddAsync(vuelo);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (vueloCache is null) return vuelo;
                return vueloCache.AddOrUpdate(vuelo.IdVuelo, vuelo, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Vuelo UpdateCache(int id, Vuelo vuelo)
        {
            Vuelo? anterior;
            if (vueloCache is not null)
            {
                if (vueloCache.TryGetValue(id, out anterior))
                {
                    if (vueloCache.TryUpdate(id, vuelo, anterior))
                    {
                        return vuelo;
                    }
                }
            }
            return null!;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Vuelo? vuelo = db.Vuelos.Find(id);
            if (vuelo is null) return null!;
            db.Vuelos.Remove(vuelo);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (vueloCache is null) return null;
                return vueloCache.TryRemove(id, out vuelo);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Vuelo>> GetAllAsync()
        {
            vueloCache = new ConcurrentDictionary<int, Vuelo>(
                    db.Vuelos.Include(v => v.IdAvionNavigation).Include(v => v.IdPilotoNavigation).ToDictionary(c => c.IdVuelo));
            return Task.FromResult(vueloCache is null ? Enumerable.Empty<Vuelo>() :
                vueloCache.Values);
        }

        public Task<Vuelo?> GetAsync(int id)
        {
            if (vueloCache is null) return null!;
            vueloCache!.TryGetValue(id, out Vuelo? vuelo);
            return Task.FromResult(vuelo);
        }

        public async Task<Vuelo?> UpdateAsync(int id, Vuelo vuelo)
        {
            db.Vuelos.Update(vuelo);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                return UpdateCache(id, vuelo);
            }
            return null;
        }
    }
}
