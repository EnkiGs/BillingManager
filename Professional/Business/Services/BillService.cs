using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Professional.Business.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository repo;

        public BillService(IBillRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            return await repo.GetBills();
        }

        public async Task<Bill> GetBill(long? id)
        {
            return id == null ? null : await repo.GetBill(id.Value);
        }

        public void AddBill(Bill bill)
        {
            repo.AddBill(bill);
        }

        public void UpdateBill(Bill bill)
        {
            repo.UpdateBill(bill);
        }

        public void DeleteBill(long id)
        {
            repo.DeleteBill(id);
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
    }
}
