using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
            //defensive coding
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değils...");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) // Doğrulama kodu olduğu için OnBefore yazıyoruz.Yani ekleme gerçekleşmeden önce doğrulama yapmalı.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
