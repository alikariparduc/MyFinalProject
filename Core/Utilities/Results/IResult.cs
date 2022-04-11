using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    //Yapılan işlemlerin başarılı olup olmadığını denetleyecek bir yapının şablonunu ,özelikklerini oluşuruyoruz.
    public interface IResult
    {
        bool Success { get; } //Sadece okunabilir
        string  Message { get; } // sadece okunabilir.
    }
}
