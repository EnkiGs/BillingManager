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
    public class WordingRepository : IWordingRepository
    {
        private BillingDbContext context;

        public WordingRepository(BillingDbContext context)
        {
            this.context = context;
        }

        public async Task<Wording> GetWording(long id)
        {
            return await context.Wordings.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Wording>> GetWordings()
        {
            return await context.Wordings.ToListAsync();
        }

        public async Task<IEnumerable<Wording>> GetWordings(IEnumerable<long> ids)
        {
            return (await context.Wordings.ToListAsync()).Where(w => ids.Contains(w.Id));
        }

        public async Task AddWording(Wording wording)
        {
            context.Add(wording);
            await context.SaveChangesAsync();
        }

        public async Task UpdateWording(Wording wording)
        {
            context.Update(wording);
            await context.SaveChangesAsync();
        }
        public async Task DeleteWording(long id)
        {
            var wording = await context.Wordings.FindAsync(id);
            context.Wordings.Remove(wording);
            await context.SaveChangesAsync();
        }

    }
}
