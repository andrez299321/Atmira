
using Contracts.Repository;
using Dto.Controller;
using Dto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RTvShow : RepositoryBase, IRTvShow
    {
        public RTvShow(AtmiraContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(TvShows request)
        {
            request.Id = 0;
            _db.TvShows.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.TvShows.Where(x => x.Id == id).FirstOrDefault();
            _db.TvShows.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<TvShows>> GetAsync()
        {
            return _db.TvShows.ToList();
        }

        public async Task<List<TvShowQueryResponse>> GetQueryAsync()
        {
            return ( from tvshow in _db.TvShows
                     join net in _db.Networks on tvshow.NetworkId equals net.Id
                     join rat in _db.Ratings on tvshow.RatingsId equals rat.Id
                     select new TvShowQueryResponse()
                     {
                         Id = tvshow.Id,
                         Name = tvshow.Name,
                         Language = tvshow.Language,
                         Ended = tvshow.Ended,
                         OfficialSite = tvshow.OfficialSite,
                         premiered = tvshow.Premiered,
                         Status = tvshow.Status,
                         Type   = tvshow.Type,
                         AverageRuntime = tvshow.AverageRuntime,
                         Url = tvshow.Url,
                         Weight = tvshow.Weight,
                         Updated = tvshow.Updated,
                         Summary = tvshow.Summary,
                         Runtime    = tvshow.Runtime,
                         AverageRating = rat.Average,
                         NameNetwork = net.Name
                     }
                     ).ToList();
        }

        public async Task<TvShows> GetByIdAsync(int id)
        {
            return _db.TvShows.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(TvShows request, int id)
        {
            var result = _db.TvShows.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _db.TvShows.Update(request);
            }
            return await _db.SaveChangesAsync();
        }
    }
}
