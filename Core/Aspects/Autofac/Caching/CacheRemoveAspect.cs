using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
   public  class CacheRemoveAspect: MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            this._cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
            this._pattern = pattern;
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            this._cacheManager.RemoveByPattern(this._pattern);
        }
    }
}
