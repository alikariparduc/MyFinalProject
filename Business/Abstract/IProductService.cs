using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>> GetAll();
        //List<Product> GetAll();
        IResult Add(Product entity); // IResult tipinde bir dönüş sağlayacak//bool success ve string Message
        IDataResult<List<Product>> GetAllByCategoryId(int id);//Kategoriye göre ürünleri listele.
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//Fiyat aralığına göre listeleme filtre operasyon
        IDataResult<List<ProductDetailDto>> GetProductDetailDtos();
        IDataResult<Product> GetById(int productId);
        IResult Update(Product product);
     
        
        
    }
}
