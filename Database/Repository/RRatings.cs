
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RRatings : RepositoryBase, IRRatings
    {
        public RRatings(AtmiraContext db) : base(db)
        {
        }

        public async Task<Ratings> GetByNameAsync(double? avr)
        {
            return _db.Ratings.Where(x => x.Average == avr).FirstOrDefault();
        }
        public async Task<int> CreateAsync(Ratings request)
        {
            _db.Ratings.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Ratings.Where(x => x.Id == id).FirstOrDefault();
            _db.Ratings.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Ratings>> GetAsync()
        {
            return _db.Ratings.ToList();
        }

        public async Task<Ratings> GetByIdAsync(int id)
        {
            return _db.Ratings.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Ratings request, int id)
        {
            var result = _db.Ratings.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Ratings.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
