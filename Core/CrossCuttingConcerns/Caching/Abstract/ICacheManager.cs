using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Abstract
{
    public  interface ICacheManager
    {
        T Get<T>(string key);  // Verilen key değerine göre bellekten  o keye karşılık olan datayı T tipinde dönecek.
        object Get(string key);//Get in generic olmayan kullanım modeli. Bunu kullanırsak tür dönüşüme gerekir.
        void Add(string key, object value, int duration);
        bool IsAdd(string key);//Cachete var mı kontrol 
        void Remove(string key); //Cacheten uçurma.
        void RemoveByPattern(string pattern); // Verilen veriye göre cache sil işlemi yapacak.



    }
}
