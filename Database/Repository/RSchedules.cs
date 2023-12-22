
using Contracts.Repository;
using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RSchedules : RepositoryBase, IRSchedules
    {
        public RSchedules(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Schedules request)
        {
            _db.Schedules.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Schedules.Where(x => x.Id == id).FirstOrDefault();
            _db.Schedules.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Schedules>> GetAsync()
        {
            return _db.Schedules.ToList();
        }

        public async Task<Schedules> GetByIdAsync(int id)
        {
            return _db.Schedules.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<Schedules> GetByNameAsync(string time)
        {
            return _db.Schedules.Where(x => x.Time == time).FirstOrDefault();
        }
        public async Task<int> UpdateAsync(Schedules request, int id)
        {
            var result = _db.Schedules.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.Schedules.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
