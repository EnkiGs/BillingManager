using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();

        Task<Client> GetClient(long id);

        void AddClient(Client client);

        void UpdateClient(Client client);

        void DeleteClient(long id);
    }
}
