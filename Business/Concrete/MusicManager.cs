using Business.Abstract;
using Business.Constants;
using Business.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class MusicManager : IMusicService
    {
        private IMusicDal _musicDal;

        public MusicManager(IMusicDal musicDal)
        {
            _musicDal = musicDal;
        }

        [ValidationAspect(typeof(MusicValidator))]
        [CacheRemoveAspect("Get")]
        //[AutorizationAspect("admin, moderator")]
        public IResult Add(Music music)
        {
            if (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 59)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            //ValidatorTool.ValidateGeneric<Music>(music, new MusicValidator());
            _musicDal.Add(music);
            return new SuccessResult(Messages.AddMovie);
        }

        [CacheRemoveAspect("Get")]
        public IResult Delete(Music music)
        {
            ValidatorTool.ValidateGeneric<Music>(music, new MusicValidator());
            _musicDal.Delete(music);
            return new SuccessResult(Messages.DeleteMovie);
        }

        public IResult Update(Music music)
        {
            ValidatorTool.ValidateGeneric<Music>(music, new MusicValidator());
            _musicDal.Update(music);
            return new SuccessResult(Messages.UpdateMovie);
        }

        [CacheAspect]
        [PerformanceAspect(0)] //????
        public IDataResult<List<Music>> GetAll(Expression<Func<Music, bool>> filter = null)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(filter));
        }

        [CacheAspect]
        public IDataResult<List<Music>> GetByMusicId(int id)
        {
           return new SuccessDataResult<List<Music>>(_musicDal.GetAll(m => m.MusicId == id));
        }

        [CacheAspect]
        public IDataResult<List<Music>> GetBySingerId(int id)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(m => m.SingerId == id));

        }

        [CacheAspect]
        public IDataResult<List<Music>> GetByMusicName(string key)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(p => p.MusicName.ToLower().Contains(key.ToLower())));
        }

        [CacheAspect]
        public IDataResult<List<Music>> GetByGenreId(int genreId)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(p => p.GenreId == genreId));
        }

        [CacheAspect]
        public IDataResult<List<MusicDetail>> GetMusicDetails()
        {
            return new SuccessDataResult<List<MusicDetail>>(_musicDal.GetMusicDetails());
        }

        public IDataResult<int> GetNextId()
        {
            return new SuccessDataResult<int>(this._musicDal.GetNextId());
        }
    }
}
