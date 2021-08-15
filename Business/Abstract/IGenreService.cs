using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGenreService
    {
        IResult Add(Genre genre);

        IResult Update(Genre genre);

        IResult Delete(Genre genre);

        IDataResult<List<Genre>> GetAll();

    }
}
