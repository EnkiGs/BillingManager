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
    public class BillRepository : IBillRepository
    {
        private BillingDbContext context;

        public BillRepository(BillingDbContext context)
        {
            this.context = context;
        }

        public async Task<Bill> GetBill(long id)
        {
            return await context.Bills.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            return await context.Bills.ToListAsync();
        }

        public async void AddBill(Bill bill)
        {
            context.Add(bill);
            await context.SaveChangesAsync();
        }

        public async void UpdateBill(Bill bill)
        {
            context.Update(bill);
            await context.SaveChangesAsync();
        }
        public async void DeleteBill(long id)
        {
            var bill = await context.Bills.FindAsync(id);
            context.Bills.Remove(bill);
            await context.SaveChangesAsync();
        }

    }
}
