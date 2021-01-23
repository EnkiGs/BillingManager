using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repo;

        public ClientService(IClientRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await repo.GetClients();
        }

        public async Task<Client> GetClient(long? id)
        {
            return !id.HasValue ? null : await repo.GetClient(id.Value);
        }

        public async Task AddClient(Client client)
        {
            await repo.AddClient(client);
        }

        public async Task UpdateClient(Client client)
        {
            await repo.UpdateClient(client);
        }

        public async Task DeleteClient(long id)
        {
            await repo.DeleteClient(id);
        }

        public async Task<string> GetClientName(long Id)
        {
            var client = await GetClient(Id);
            if(client == null)
            {
                return string.Empty;
            }
            else
            {
                return GetClientName(client);
            }
        }

        public string GetClientName(Client client)
        {
            return client.Civil == Title.Société ? client.Societe : client.Nom + client.Prenom;
        }
    }
}
