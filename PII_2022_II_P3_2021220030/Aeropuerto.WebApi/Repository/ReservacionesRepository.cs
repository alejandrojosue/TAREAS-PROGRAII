using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Concurrent;

namespace Aeropuerto.WebApi.Repository
{
    public class ReservacionesRepository:IReservacionRepository
    {
        private static ConcurrentDictionary<int, Reservacione>? ReservacionCache;
        private readonly aeropuertoDBContext? db;

        public ReservacionesRepository(aeropuertoDBContext contextoInyectado)
        {
            db = contextoInyectado;
            if (ReservacionCache is null)
            {
                ReservacionCache = new ConcurrentDictionary<int, Reservacione>(
                    db.Reservaciones.Include(r => r.IdClienteNavigation).Include(r => r.IdVueloNavigation).ToDictionary(c => c.IdReservacion));
            }
        }

        public async Task<Reservacione?> CreateAsync(Reservacione Reservacion)
        {
            EntityEntry<Reservacione> adicionado = await db!.Reservaciones.AddAsync(Reservacion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (ReservacionCache is null) return Reservacion;
                return ReservacionCache.AddOrUpdate(Reservacion.IdReservacion, Reservacion, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Reservacione UpdateCache(int id, Reservacione Reservacion)
        {
            Reservacione? anterior;
            if (ReservacionCache is not null)
            {
                if (ReservacionCache.TryGetValue(id, out anterior))
                {
                    if (ReservacionCache.TryUpdate(id, Reservacion, anterior))
                    {
                        return Reservacion;
                    }
                }
            }
            return null!;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Reservacione? Reservacion = db!.Reservaciones.Find(id);
            if (Reservacion is null) return null!;
            db.Reservaciones.Remove(Reservacion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (ReservacionCache is null) return null;
                return ReservacionCache.TryRemove(id, out Reservacion);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Reservacione>> GetAllAsync()
        {
            ReservacionCache = new ConcurrentDictionary<int, Reservacione>(
                    db!.Reservaciones.Include(r => r.IdClienteNavigation).Include(r => r.IdVueloNavigation).ToDictionary(c => c.IdReservacion));
            return Task.FromResult(ReservacionCache is null ? Enumerable.Empty<Reservacione>() :
                ReservacionCache.Values);
        }
        public Task<Reservacione?> GetAsync(int id)
        {
            if (ReservacionCache is null) return null!;
            ReservacionCache.TryGetValue(id, out Reservacione? Reservacion);
            
            return Task.FromResult(Reservacion);
        }

        public async Task<Reservacione?> UpdateAsync(int id, Reservacione Reservacion)
        {
            db!.Reservaciones.Update(Reservacion);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                return UpdateCache(id, Reservacion);
            }
            return null;
        }
    }
}
