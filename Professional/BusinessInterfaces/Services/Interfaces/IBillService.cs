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

        void AddBill(Bill bill);

        void UpdateBill(Bill bill);

        void DeleteBill(long id);

        Task<int> CountBillsForYear(int year);
    }
}
