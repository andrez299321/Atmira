
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RSelves : RepositoryBase, IRSelves
    {
        public RSelves(AtmiraContext db) : base(db)
        {
        }

        public async Task<Selves> GetByNameAsync(string Href)
        {
            return _db.Selves.Where(x => x.Href == Href).FirstOrDefault();
        }
        public async Task<int> CreateAsync(Selves request)
        {
            _db.Selves.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Selves.Where(x => x.Id == id).FirstOrDefault();
            _db.Selves.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Selves>> GetAsync()
        {
            return _db.Selves.ToList();
        }

        public async Task<Selves> GetByIdAsync(int id)
        {
            return _db.Selves.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Selves request, int id)
        {
            var result = _db.Selves.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Selves.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
