using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    scope.Complete();
                }
                catch (System.Exception)
                {
                    scope.Dispose(); 
                    throw;
                }
            }
          
        }
    }
}
