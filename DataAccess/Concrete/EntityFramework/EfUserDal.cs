using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MusicLibraryContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
            //using (var context = new MusicLibraryContext())
            //{
            //    var result = from operationClaim in context.OperationClaims
            //                 join userOperationClaim in context.UserOperationClaims
            //                    on operationClaim.Id equals userOperationClaim.OperationClaimId
            //                 where userOperationClaim.UserId == user.Id
            //                 select new OperationClaim
            //                 {
            //                     Id = operationClaim.Id,
            //                     Name = operationClaim.Name
            //                 };

            //    return result.ToList();
            //}
        }
    }
}
