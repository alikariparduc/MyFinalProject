using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Müşteri giriş yaptığında yani şifresi doğru ise otomatik CrateToken metodu çalışacak.İlgili kullanııc için veritabanına gidip kullanııcnın OperationClaim tablosundaki
        //claimlerini bulacak orda bir json web token (jwt) üretecek ve kullanıcıın aktif bir tokenı olacak.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
