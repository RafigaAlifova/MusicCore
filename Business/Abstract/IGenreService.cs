using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGenreService
    {
        void Add(Genre genre);

        void Update(Genre genre);

        void Delete(Genre genre);

        List<Genre> GetAll();

    }
}
