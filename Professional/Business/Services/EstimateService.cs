using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Business.Services
{
    public class EstimateService : IEstimateService
    {
        private readonly IEstimateRepository EstimatesRepo;

        public EstimateService(IEstimateRepository repo)
        {
            EstimatesRepo = repo;
        }

        public async Task<IEnumerable<Estimate>> GetEstimates()
        {
            List<Estimate> Estimates = (await EstimatesRepo.GetEstimates()).ToList();

            return Estimates;
        }

        public async Task<Estimate> GetEstimate(long? id)
        {
            Estimate Estimate = null;
            if (id.HasValue)
            {
                Estimate = await EstimatesRepo.GetEstimate(id.Value);
            }
            return Estimate;
        }

        public async Task AddEstimate(Estimate Estimate)
        {
            await EstimatesRepo.AddEstimate(Estimate);
        }

        public async Task UpdateEstimate(Estimate Estimate)
        {
            await EstimatesRepo.UpdateEstimate(Estimate);
        }

        public async Task DeleteEstimate(long id)
        {
            await EstimatesRepo.DeleteEstimate(id);
        }

        public async Task<int> CountEstimatesForYear(int year)
        {
            var Estimates = await GetEstimates();
            if (!Estimates.Any())
                return 0;

            var EstimatesForYear = Estimates.Where(b => b.Year == year);
            if (!EstimatesForYear.Any())
                return 0;
            return EstimatesForYear.Max(b => b.Num);
        }
        public async Task<IEnumerable<string>> GetRegularObjects()
        {
            return await EstimatesRepo.GetRegularObjects();
        }

        public async Task<IEnumerable<string>> GetRegularDescriptions()
        {
            return await EstimatesRepo.GetRegularDescriptions();
        }
    }
}
