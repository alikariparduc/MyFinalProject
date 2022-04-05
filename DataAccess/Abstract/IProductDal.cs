using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Entities katmanındaki product classının DataAccess katmanındaki erişim Interfacesi  =DataAccessLayer(DAL)
    public interface IProductDal:IEntityRepository<Product>
    { 
    }
}
