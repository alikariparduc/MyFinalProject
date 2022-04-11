using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult // Hangi tipi döndüreceğini belirt.<T>
    {
         T Data { get; }
    }
}
