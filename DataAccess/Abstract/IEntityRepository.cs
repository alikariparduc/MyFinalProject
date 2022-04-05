using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint ?
    //class :Referans tip olabilir
    //***public interface IEntityRepository<T>where T:class,IEntity //Burada T yi sınırlandırdık.
    //Artık T  IEntity tipinde bir class olabilir. Yani int ,string gibi tanımlamalar yapılamaz.
    //ProductDal,CustomerDal,CategoryDal gibi IEntity'nin referansını ttuttuğu classlar olabilir.***//
    //new() : newlenebilir olmalıdır.Böylece IEntity verilemeyecek onun implemente ettiği classlar verilebilecek.
    public interface IEntityRepository<T>where T:class,IEntity,new()//Temel DataAccess işlemlerinin şablonu(ProductDal,CategoryDal,CustomerDal vb.)
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null); // Liste dönmesi için 
        T Get(Expression<Func<T,bool>>filter); // Tek bir değer dönmesi için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllCategory(int categoryId);
    }
}
