using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Concurrent;

namespace Aeropuerto.WebApi.Repository
{
    public class CargosRepository: ICargoRepository
    {
        private static ConcurrentDictionary<int, Cargo>? cargoCache;
        private aeropuertoDBContext db;

        public CargosRepository(aeropuertoDBContext contextoInyectado)
        {
            this.db = contextoInyectado;
            if (cargoCache is null)
            {
                cargoCache = new ConcurrentDictionary<int, Cargo>(
                    db.Cargos.ToDictionary(c => c.IdCargo));
            }
        }

        public async Task<Cargo?> CreateAsync(Cargo cargo)
        {
            EntityEntry<Cargo> adicionado = await db.Cargos.AddAsync(cargo);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (cargoCache is null) return cargo;
                return cargoCache.AddOrUpdate(cargo.IdCargo, cargo, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Cargo UpdateCache(int id, Cargo cargo)
        {
            Cargo? anterior;
            if (cargoCache is not null)
            {
                if (cargoCache.TryGetValue(id, out anterior))
                {
                    if (cargoCache.TryUpdate(id, cargo, anterior))
                    {
                        return cargo;
                    }
                }
            }
            return null!;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Cargo? cargo = db.Cargos.Find(id);
            if (cargo is null) return null!;
            db.Cargos.Remove(cargo);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (cargoCache is null) return null;
                return cargoCache.TryRemove(id, out cargo);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return Task.FromResult(cargoCache is null ? Enumerable.Empty<Cargo>() :
                cargoCache.Values);
        }

        public Task<Cargo?> GetAsync(int id)
        {
            if (cargoCache is null) return null!;
            cargoCache!.TryGetValue(id, out Cargo? cargo);
            return Task.FromResult(cargo);
        }

        public async Task<Cargo?> UpdateAsync(int id, Cargo cargo)
        {
            db.Cargos.Update(cargo);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                return UpdateCache(id, cargo);
            }
            return null;
        }
    }
}
