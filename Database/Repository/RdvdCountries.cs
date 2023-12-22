
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RdvdCountries : RepositoryBase, IRDvdCountries
    {
        public RdvdCountries(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(DvdCountries request)
        {
            _db.DvdCountries.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.DvdCountries.Where(x => x.Id == id).FirstOrDefault();
            _db.DvdCountries.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<DvdCountries>> GetAsync()
        {
            return _db.DvdCountries.ToList();
        }

        public async Task<DvdCountries> GetByIdAsync(int id)
        {
            return _db.DvdCountries.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(DvdCountries request, int id)
        {
            var result = _db.DvdCountries.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.DvdCountries.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
