using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.BusinessInterfaces.Services.Interfaces
{
    public interface IEstimateService
    {
        Task<IEnumerable<Estimate>> GetEstimates();

        Task<Estimate> GetEstimate(long? id);

        Task AddEstimate(Estimate Estimate);

        Task UpdateEstimate(Estimate Estimate);

        Task DeleteEstimate(long id);

        Task<int> CountEstimatesForYear(int year);
        
        Task<IEnumerable<string>> GetRegularObjects();

        Task<IEnumerable<string>> GetRegularDescriptions();
    }
}
