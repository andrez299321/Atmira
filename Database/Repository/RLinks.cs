
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RLinks : RepositoryBase, IRLinks
    {
        public RLinks(AtmiraContext db) : base(db)
        {
        }

        public async Task<Links> GetByNameAsync(string SelfHref)
        {
            return _db.Links.Where(x => x.SelfHref == SelfHref).FirstOrDefault();
        }
        public async Task<int> CreateAsync(Links request)
        {
            _db.Links.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Links.Where(x => x.Id == id).FirstOrDefault();
            _db.Links.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Links>> GetAsync()
        {
            return _db.Links.ToList();
        }

        public async Task<Links> GetByIdAsync(int id)
        {
            return _db.Links.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Links request, int id)
        {
            var result = _db.Links.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Links.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
