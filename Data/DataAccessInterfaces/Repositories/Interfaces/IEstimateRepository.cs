using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces.Repositories.Interfaces
{
    public interface IEstimateRepository
    {
        Task<IEnumerable<Estimate>> GetEstimates();

        Task<Estimate> GetEstimate(long id);

        Task AddEstimate(Estimate estimate);

        Task UpdateEstimate(Estimate estimate);

        Task DeleteEstimate(long id);
    }
}
