using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants // Constants = Sabit // Projenin sabitlerini tutacağız burada.
{
    public static class Messages //newlememek için static yaptık.
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        internal static string MaintenanceTime="Sistem Bakımda";
        internal static string ProductsListed="Ürünler Listelendi.";
    }
}
