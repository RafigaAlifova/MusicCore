using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenreDal : EfEntityRepositoryBase<Genre, MusicLibraryContext>, IGenreDal
    {

    }
}
