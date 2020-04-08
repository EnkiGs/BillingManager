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
    public class EstimateRepository : IEstimateRepository
    {
        private readonly BillingDbContext context;

        public EstimateRepository(BillingDbContext context)
        {
            this.context = context;
        }

        public async Task<Estimate> GetEstimate(long id)
        {
            return await context.Estimates.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Estimate>> GetEstimates()
        {
            return await context.Estimates.ToListAsync();
        }

        public async void AddEstimate(Estimate estimate)
        {
            context.Add(estimate);
            await context.SaveChangesAsync();
        }

        public async void UpdateEstimate(Estimate estimate)
        {
            try
            {
                context.Update(estimate);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async void DeleteEstimate(long id)
        {
            var estimate = await context.Estimates.FindAsync(id);
            context.Estimates.Remove(estimate);
            await context.SaveChangesAsync();
        }
    }
}
