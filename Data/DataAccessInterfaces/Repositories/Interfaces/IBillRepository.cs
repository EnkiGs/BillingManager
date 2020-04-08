using Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces.Repositories.Interfaces
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetBills();

        Task<Bill> GetBill(long id);

        void AddBill(Bill bill);

        void UpdateBill(Bill bill);

        void DeleteBill(long id);
    }
}
