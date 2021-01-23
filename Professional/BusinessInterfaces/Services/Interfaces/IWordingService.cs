using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.BusinessInterfaces.Services.Interfaces
{
    public interface IWordingService
    {
        Task<IEnumerable<Wording>> GetWordings();

        Task<IEnumerable<Wording>> GetWordings(IEnumerable<long> ids);

        Task<Wording> GetWording(long? id);

        Task AddWording(Wording wording);

        Task UpdateWording(Wording wording);

        Task DeleteWording(long id);
    }
}
