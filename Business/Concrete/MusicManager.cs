using Business.Abstract;
using Business.Constants;
using Business.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Interceptors;
using Business.BusinessAspects.Autofac;

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
        [SecuredOperation("product.add")]
        public IResult Add(Music music)
        {
           IResult result= BusinessRules.Run(CheckIfMaintenanceTime(),
                CheckIfMusicCountOfGenre(music.GenreId),
                CheckIfMusicNameExists(music.MusicName));

            if (result!=null)
            {
                return result;
            }

            _musicDal.Add(music);
            return new SuccessResult(Messages.AddMusic);
        }

        [CacheRemoveAspect("Get")]
        public IResult Delete(Music music)
        {
            _musicDal.Delete(music);
            return new SuccessResult(Messages.DeleteMusic);
        }

        [ValidationAspect(typeof(MusicValidator))]
        public IResult Update(Music music)
        {
            _musicDal.Update(music);
            return new SuccessResult(Messages.UpdateMusic);
        }

        [CacheAspect]
        [PerformanceAspect(0)] 
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

              private IResult CheckIfMusicCountOfGenre(int genreId)
        {
            var result = _musicDal.GetAll(p => p.GenreId == genreId);
            if (result.Count >= 10)
            {
                return new ErrorResult(Messages.MusicCountOfGenreError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfMusicNameExists(string musicName)
        {
            var result = _musicDal.GetAll(p => p.MusicName == musicName).Any();
            if (result)
            {
                return new ErrorResult(Messages.MusicNameAlreadyExists);
            }
            return new SuccessResult();
        } 

        private IResult CheckIfMaintenanceTime()
        {
            if ((DateTime.Now.Hour == 23 && DateTime.Now.Minute == 59))
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult();
        }

    }

    
}
