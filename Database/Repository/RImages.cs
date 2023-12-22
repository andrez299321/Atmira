
using Contracts.Repository;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RImages : RepositoryBase, IRImages
    {
        public RImages(AtmiraContext db) : base(db)
        {
        }

        public async Task<Images> GetByNameAsync(string Original)
        {
            return _db.Images.Where(x => x.Original == Original).FirstOrDefault();
        }
        public async Task<int> CreateAsync(Images request)
        {
            _db.Images.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Images.Where(x => x.Id == id).FirstOrDefault();
            _db.Images.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Images>> GetAsync()
        {
            return _db.Images.ToList();
        }

        public async Task<Images> GetByIdAsync(int id)
        {
            return _db.Images.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Images request, int id)
        {
            var result = _db.Images.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Images.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
