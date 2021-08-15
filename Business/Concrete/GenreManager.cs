using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public IResult Add(Genre genre)
        {
            _genreDal.Add(genre);
            return new SuccessResult();

        }

        public IResult Delete(Genre genre)
        {
            _genreDal.Delete(genre);
            return new SuccessResult();
        }

        
        public IResult Update(Genre genre)
        {
            _genreDal.Update(genre);
            return new SuccessResult();

        }

        public IDataResult<List<Genre>> GetAll()
        {
          
            return new SuccessDataResult<List<Genre>>(_genreDal.GetAll());
        }

    }
}
