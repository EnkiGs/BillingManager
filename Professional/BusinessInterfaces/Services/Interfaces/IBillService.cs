using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.BusinessInterfaces.Services.Interfaces
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetBills();

        Task<Bill> GetBill(long? id);

        Task AddBill(Bill bill);

        Task UpdateBill(Bill bill);

        Task DeleteBill(long id);

        Task<int> CountBillsForYear(int year);
    }
}
