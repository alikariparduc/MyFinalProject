using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule // Servis bağımlılıklarını çözümleyeceğiz burada.
    {
        public void Load(IServiceCollection serviceCollection)  
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Birisi senden IHttpContextAccessor isterse ona HttpContextAccessor ver.
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); // Birisi senden ICacheManager isterse ona MemoryCacheManger ver.
        }
    }
}
