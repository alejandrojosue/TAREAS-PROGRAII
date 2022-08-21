using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Concurrent;

namespace Aeropuerto.WebApi.Repository
{
    public class AvionesRepository:IAvionRepository
    {
        private static ConcurrentDictionary<int, Avione>? AvionCache;
        private aeropuertoDBContext db;

        public AvionesRepository(aeropuertoDBContext contextoInyectado)
        {
            this.db = contextoInyectado;
            if (AvionCache is null)
            {
                AvionCache = new ConcurrentDictionary<int, Avione>(
                    db.Aviones.ToDictionary(c => c.IdAvion));
            }
        }

        public async Task<Avione?> CreateAsync(Avione avion)
        {
            EntityEntry<Avione> adicionado = await db.Aviones.AddAsync(avion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (AvionCache is null) return avion;
                return AvionCache.AddOrUpdate(avion.IdAvion, avion, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Avione UpdateCache(int id, Avione avion)
        {
            Avione? anterior;
            if (AvionCache is not null)
            {
                if (AvionCache.TryGetValue(id, out anterior))
                {
                    if (AvionCache.TryUpdate(id, avion, anterior))
                    {
                        return avion;
                    }
                }
            }
            return null!;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Avione? avion = db.Aviones.Find(id);
            if (avion is null) return null!;
            db.Aviones.Remove(avion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (AvionCache is null) return null;
                return AvionCache.TryRemove(id, out avion);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Avione>> GetAllAsync()
        {
            return Task.FromResult(AvionCache is null ? Enumerable.Empty<Avione>() :
                AvionCache.Values);
        }

        public Task<Avione?> GetAsync(int id)
        {
            if (AvionCache is null) return null!;
            AvionCache!.TryGetValue(id, out Avione? avion);
            return Task.FromResult(avion);
        }

        public async Task<Avione?> UpdateAsync(int id, Avione avion)
        {
            db.Aviones.Update(avion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                return UpdateCache(id, avion);
            }
            return null;
        }
    }
}
