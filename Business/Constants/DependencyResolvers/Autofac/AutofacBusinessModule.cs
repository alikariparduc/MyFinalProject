using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.DependencyResolvers.Autofac
{
    class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
