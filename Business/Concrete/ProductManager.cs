using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;
using Business.CCS;
using System.Linq;

namespace Business.Concrete
{
    //İş kodları bu katmanda yazılır.Örk Add işlemi çalışmadan önce kontrol edilmesi gereken hususlar var ise (şartlar) burada kodlanır.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;
        public ProductManager(IProductDal productDal,ILogger logger)
        {
            _productDal = productDal;
            _logger = logger;
        }

       // [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            ////ValidationTool.Validate(new ProductValidator(), product);
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //if (product.ProductName.Length < 2)
            //{

            //    return new ErrorResult(Messages.ProductNameInvalid);//Messages.ProductNameInvalid =>magic string
            //}

            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)//Kural uygunluğunu sağlıyorsa ekle.
            {
                _productDal.Add(product);
                //return new Result(true,"Ürün eklendi...");
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult(Messages.ProductAddedError);

            
            
          


          

        }

        public Product Get(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==12)
            {
                return new  ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
            
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
           
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max));
            
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductAddedError);
            }
            return new SuccessResult();
        }
    }
}
