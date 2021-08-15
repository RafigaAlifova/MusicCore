using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IMusicService
    {
        IResult Add(Music music);

        IResult Update(Music music);

        IResult Delete(Music music);

        IDataResult<List<Music>> GetAll(Expression<Func<Music, bool>> filter = null);

        IDataResult<List<Music>> GetByMusicId(int id);

        IDataResult<List<Music>> GetBySingerId(int id);

        IDataResult<List<Music>> GetByMusicName(string key);

        IDataResult<List<Music>> GetByGenreId(int selectedValue);

        IDataResult<List<MusicDetail>> GetMusicDetails();

        IDataResult<int> GetNextId();
    }
}
