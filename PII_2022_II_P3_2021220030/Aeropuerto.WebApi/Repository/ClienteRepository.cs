using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Concurrent;
using System.Linq;

namespace Aeropuerto.WebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        //aqui
        private static ConcurrentDictionary<int, Cliente>? clienteCache;
        private aeropuertoDBContext db;

        public ClienteRepository(aeropuertoDBContext contextoInyectado)
        {
            this.db = contextoInyectado;
            if (clienteCache is null)
            {
                //y aqui
                clienteCache = new ConcurrentDictionary<int, Cliente>(
                    db.Clientes.ToDictionary(c => c.IdCliente));
            }
        }

        public async Task<Cliente?> CreateAsync(Cliente cliente)
        {
            EntityEntry<Cliente> adicionado = await db.Clientes.AddAsync(cliente);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (clienteCache is null) return cliente;
                return clienteCache.AddOrUpdate(cliente.IdCliente, cliente, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Cliente UpdateCache(int id, Cliente customer)
        {
            Cliente? anterior;
            if (clienteCache is not null)
            {
                if (clienteCache.TryGetValue(id, out anterior))
                {
                    if (clienteCache.TryUpdate(id, customer, anterior))
                    {
                        return customer;
                    }
                }
            }
            return null!;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Cliente? customer = db.Clientes.Find(id);
            if (customer is null) return null!;
            db.Clientes.Remove(customer);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                if (clienteCache is null) return null;
                return clienteCache.TryRemove(id, out customer);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return Task.FromResult(clienteCache is null ? Enumerable.Empty<Cliente>() :
                clienteCache.Values);
        }

        public Task<Cliente?> GetAsync(int id)
        {
            if (clienteCache is null) return null!;
            clienteCache!.TryGetValue(id, out Cliente? customer);
            return Task.FromResult(customer);
        }

        public async Task<Cliente?> UpdateAsync(int id, Cliente customer)
        {
            db.Clientes.Update(customer);
            int afectado = await db.SaveChangesAsync();
            if (afectado == 1)
            {
                return UpdateCache(id, customer);
            }
            return null;
        }

    }
}
