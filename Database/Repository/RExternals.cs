
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RExternals : RepositoryBase, IRExternals
    {
        public RExternals(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Externals request)
        {
            _db.Externals.Add(request);
            return await _db.SaveChangesAsync();
        }
        public async Task<Externals> GetByNameAsync(Externals ext )
        {
            return _db.Externals.Where(x => x.Imdb == ext.Imdb && x.Thetvdb == ext.Thetvdb && x.Tvrage == ext.Tvrage).FirstOrDefault();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Externals.Where(x => x.Id == id).FirstOrDefault();
            _db.Externals.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Externals>> GetAsync()
        {
            return _db.Externals.ToList();
        }

        public async Task<Externals> GetByIdAsync(int id)
        {
            return _db.Externals.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Externals request, int id)
        {
            var result = _db.Externals.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Externals.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
