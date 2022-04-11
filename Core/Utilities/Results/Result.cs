using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)//:this(success) => Bu class çalışınca successte çalışacak.Böylece iste message+success
            //ister sadece success dönülebilir.
        // Constructor // newlendiğinde bir success bilgisi birde message ver diyor.
        {
            Message = message;
        }
     
        public Result(bool success)  //Overloading  // Sadece success dönmek istediğimiz zaman Bu overloading kullanıcaz
        {
             
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
