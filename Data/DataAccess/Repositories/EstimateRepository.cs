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
            return await context.Estimates
                .Include(e => e.LibelleList)
                .Include(e => e.Client)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Estimate>> GetEstimates()
        {
            return await context.Estimates.Include(e => e.LibelleList).Include(e => e.Client).ToListAsync();
        }

        public async Task AddEstimate(Estimate estimate)
        {
            context.Add(estimate);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEstimate(Estimate estimate)
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

        public async Task DeleteEstimate(long id)
        {
            var estimate = await context.Estimates.FindAsync(id);
            context.Estimates.Remove(estimate);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetRegularObjects()
        {
            return await context.Estimates.Where(b => !string.IsNullOrEmpty(b.Objet)).Select(b => b.Objet).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRegularDescriptions()
        {
            return await context.Wordings.Where(w => !string.IsNullOrEmpty(w.Content)).Select(w => w.Content).ToListAsync();
        }
    }
}
