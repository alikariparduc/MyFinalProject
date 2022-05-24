using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules // İş kurallarımızı burada metod aracılığıyla çağırıyoruz.
    {
        public static IResult Run(params IResult[] logics) // İş kurallarını IResult[] array tipinde parametre ile gönderiyoruz metoda.
        {
            foreach (var logic in logics) // Gönderilen iş kurallarını gezecek.
            {
                if (logic.Success==false)//İş kurallarından false dönen varsa , kuralların sağlanmadığı bir durum var ise kontrolü yapılıyor.
                {
                    return logic;// Yukarıda false dönen iş kuralını return ediyor.
                }
            }
            return null;//İş kurulanıa uymayan bir durum yok ise.logic.Success true ise herhangi bir şey dönmeyecek.Yani iş kuralı kaynaklı bir hata dönemeyecek.
        }
    }
}
