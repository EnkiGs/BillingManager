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
            return id == null ? null : await repo.GetClient(id.Value);
        }

        public void AddClient(Client client)
        {
            repo.AddClient(client);
        }

        public void UpdateClient(Client client)
        {
            repo.UpdateClient(client);
        }

        public void DeleteClient(long id)
        {
            repo.DeleteClient(id);
        }
    }
}
