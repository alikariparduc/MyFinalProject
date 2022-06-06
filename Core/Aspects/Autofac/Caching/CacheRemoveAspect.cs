using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;


        // Cache nezaman silinir ?  :> Veri bozulunca.Yani veri silinirse,eklenirse , güncellenirse cache bozulacağından silinir.
        public CacheRemoveAspect(string pattern) 
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}

