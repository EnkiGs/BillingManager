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

        Task AddBill(Bill bill);

        Task UpdateBill(Bill bill);

        Task DeleteBill(long id);
    }
}
