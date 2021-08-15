using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SingerManager : ISingerService
    {
        ISingerDal _singerDal;

        public SingerManager(ISingerDal genreDal)
        {
            _singerDal = genreDal;
        }

        public void Add(Singer singer)
        {
            _singerDal.Add(singer);
        }

        public void Delete(Singer singer)
        {
            _singerDal.Delete(singer);
        }

        public List<Singer> GetAll()
        {
            return _singerDal.GetAll();
        }

        public void Update(Singer singer)
        {
            _singerDal.Update(singer);
        }


    }
}
