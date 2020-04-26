using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BillingDbContext context;

        public ClientRepository(BillingDbContext context)
        {
            this.context = context;
        }
        public async Task<Client> GetClient(long id)
        {
            return await context.Clients.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task AddClient(Client client)
        {
            context.Add(client);
            await context.SaveChangesAsync();
        }

        public async Task UpdateClient(Client client)
        {
            try
            {
                context.Update(client);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task DeleteClient(long id)
        {
            var client = await context.Clients.FindAsync(id);
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
