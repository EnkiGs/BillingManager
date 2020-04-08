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

        void AddEstimate(Estimate estimate);

        void UpdateEstimate(Estimate estimate);

        void DeleteEstimate(long id);
    }
}
