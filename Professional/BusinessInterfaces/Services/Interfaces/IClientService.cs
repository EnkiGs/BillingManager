using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.BusinessInterfaces.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();

        Task<Client> GetClient(long? id);

        Task AddClient(Client client);

        Task UpdateClient(Client client);

        Task DeleteClient(long id);

        Task<string> GetClientName(long Id);

        string GetClientName(Client client);
    }
}
