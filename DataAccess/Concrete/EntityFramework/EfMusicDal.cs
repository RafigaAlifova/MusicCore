using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMusicDal : EfEntityRepositoryBase<Music, MusicLibraryContext>, IMusicDal
    {
        public List<MusicDetail> GetMusicDetails(Expression<Func<Music, bool>> filter = null)
        {
            using (MusicLibraryContext context = new MusicLibraryContext())
            {
                var result = from m in filter == null ? context.Musics : context.Musics.Where(filter)
                             join g in context.Genres on m.GenreId equals g.GenreId
                             join s in context.Singers on m.SingerId equals s.SingerId
                             select new MusicDetail
                             {
                                 MusicId = m.MusicId,
                                 MusicName = m.MusicName,
                                 SingerName = s.SingerName,
                                 GenreName = g.GenreName,
                             };
                return result.ToList();
            }


        }
    }
}
