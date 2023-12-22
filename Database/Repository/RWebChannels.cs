
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RWebChannels : RepositoryBase, IRWebChannels
    {
        public RWebChannels(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(WebChannels request)
        {
            _db.WebChannels.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.WebChannels.Where(x => x.Id == id).FirstOrDefault();
            _db.WebChannels.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<WebChannels>> GetAsync()
        {
            return _db.WebChannels.ToList();
        }

        public async Task<WebChannels> GetByIdAsync(int id)
        {
            return _db.WebChannels.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(WebChannels request, int id)
        {
            var result = _db.WebChannels.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.WebChannels.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
