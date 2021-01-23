using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Professional.BusinessInterfaces.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Professional.Business.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository billsRepo;

        public BillService(IBillRepository repo)
        {
            billsRepo = repo;
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            List<Bill> bills = (await billsRepo.GetBills()).ToList();

            return bills;
        }

        public async Task<Bill> GetBill(long? id)
        {
            Bill bill = null;
            if(id.HasValue)
            {
                bill = await billsRepo.GetBill(id.Value);
            }
            return bill;
        }

        public async Task AddBill(Bill bill)
        {
            await billsRepo.AddBill(bill);
        }

        public async Task UpdateBill(Bill bill)
        {
            await billsRepo.UpdateBill(bill);
        }

        public async Task DeleteBill(long id)
        {
            await billsRepo.DeleteBill(id);
        }

        public async Task<int> CountBillsForYear(int year)
        {
            var bills = await GetBills();
            if (!bills.Any())
                return 0;

            var billsForYear = bills.Where(b => b.Year == year);
            if (!billsForYear.Any())
                return 0;
            return billsForYear.Max(b => b.Num);
        }

        public async Task<IEnumerable<string>> GetRegularObjects()
        {
            return await billsRepo.GetRegularObjects();
        }

        public async Task<IEnumerable<string>> GetRegularDescriptions()
        {
            return await billsRepo.GetRegularDescriptions();
        }
    }
}
