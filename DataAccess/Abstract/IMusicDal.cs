using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;


namespace DataAccess.Abstract
{
    public interface IMusicDal : IEntityRepository<Music>
    {
        List<MusicDetail> GetMusicDetails(Expression<Func<Music, bool>> filter = null);

    }
}
