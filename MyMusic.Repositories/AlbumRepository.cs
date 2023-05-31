using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyMusic.EFCoreDbFirst;

namespace MyMusic.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private readonly MyMusicDbFirstContext _ctx;

        public AlbumRepository(MyMusicDbFirstContext ctx)
        {
            _ctx = ctx;
        }

        public void Insert(Album entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Album entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> SearchFor(Expression<Func<Album, bool>> predicate)
        {
            return _ctx.Album.Include(a => a.Artist)
                .Include(a => a.Song).Where(predicate);
        }

        public IQueryable<Album> GetAll()
        {
            throw new NotImplementedException();
        }

        public Album GetById(long id)
        {
            return _ctx.Album.Include(a => a.Artist)
                .Include(a => a.Song).FirstOrDefault(a => a.Id == id);
        }
    }
}
