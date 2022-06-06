using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Trancation
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        { //Transaction yönetimi : Örnek olarak iki hesap arasındaki para transferi.Bir hesaptan bakiyeyi düşürür karşı tarafa başarılı giderse bakiyeyi oraya yazar.
            //Eğer işlem bir şekilde başarılı olmaz hataya düşerse yaptığı işlemleri geri alır yani hesaptan çıkan bakiye geri iade olmuş olur.
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); // Metodu çalıştır.
                    transactionScope.Complete(); // Başarılı ise complete et bitir.
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); //Değilse işlemleri geri al. //
                    throw;
                }
            }
        }
    }
}
