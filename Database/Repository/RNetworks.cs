
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RNetworks : RepositoryBase, IRNetworks
    {
        public RNetworks(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Networks request)
        {
            request.Id = 0;
            _db.Networks.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Networks.Where(x => x.Id == id).FirstOrDefault();
            _db.Networks.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Networks>> GetAsync()
        {
            return _db.Networks.ToList();
        }

        public async Task<Networks> GetByIdAsync(int id)
        {
            return _db.Networks.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Networks> GetByNameAsync(string name)
        {
            return _db.Networks.Where(x => x.Name == name).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Networks request, int id)
        {
            var result = _db.Networks.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Networks.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
