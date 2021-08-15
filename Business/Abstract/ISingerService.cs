using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISingerService
    {

        void Add(Singer singer);

        void Update(Singer singer);

        void Delete(Singer singer);

        List<Singer> GetAll();


    }
}
