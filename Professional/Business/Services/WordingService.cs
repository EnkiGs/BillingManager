using Common.EntityModels;
using DataAccessInterfaces.Repositories.Interfaces;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Business.Services
{
    public class WordingService : IWordingService
    {
        private readonly IWordingRepository repo;

        public WordingService(IWordingRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Wording>> GetWordings()
        {
            return await repo.GetWordings();
        }

        public async Task<IEnumerable<Wording>> GetWordings(IEnumerable<long> ids)
        {
            return await repo.GetWordings(ids);
        }

        public async Task<Wording> GetWording(long? id)
        {
            return id.HasValue ? null : await repo.GetWording(id.Value);
        }

        public async Task AddWording(Wording wording)
        {
            await repo.AddWording(wording);
        }

        public async Task UpdateWording(Wording wording)
        {
            await repo.UpdateWording(wording);
        }

        public async Task DeleteWording(long id)
        {
            await repo.DeleteWording(id);
        }
    }
}
