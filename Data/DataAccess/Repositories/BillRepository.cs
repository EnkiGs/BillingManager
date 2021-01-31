using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataAccess.Repositories
{
    public class BillRepository : IBillRepository
    {
        private BillingDbContext context;

        public BillRepository(BillingDbContext context)
        {
            this.context = context;
        }

        public async Task<Bill> GetBill(long id)
        {
            return await context.Bills
                .Include(e => e.LibelleList)
                .Include(e => e.Client)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            return await context.Bills.Include(e => e.LibelleList).Include(e => e.Client).ToListAsync();
        }

        public async Task AddBill(Bill bill)
        {
            context.Add(bill);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBill(Bill bill)
        {
            context.Update(bill);
            await context.SaveChangesAsync();
        }
        public async Task DeleteBill(long id)
        {
            var bill = await context.Bills.FindAsync(id);
            context.Bills.Remove(bill);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetRegularObjects()
        {
            return await context.Bills.Where(b => !string.IsNullOrEmpty(b.Objet)).Select(b => b.Objet).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRegularDescriptions()
        {
            return await context.Wordings.Where(w => !string.IsNullOrEmpty(w.Content)).Select(w => w.Content).ToListAsync();
        }

    }
}
