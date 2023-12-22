
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RCountries : RepositoryBase, IRCountries
    {
        public RCountries(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Countries request)
        {
            _db.Countries.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Countries.Where(x => x.Id == id).FirstOrDefault();
            _db.Countries.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Countries>> GetAsync()
        {
            return _db.Countries.ToList();
        }

        public async Task<Countries> GetByIdAsync(int id)
        {
            return _db.Countries.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Countries> GetByNameAsync(string name)
        {
            return _db.Countries.Where(x => x.Name == name).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Countries request, int id)
        {
            var result = _db.Countries.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Countries.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
