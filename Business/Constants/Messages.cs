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
        public static string MaintenanceTime="Sistem Bakımda";
        public static string ProductsListed="Ürünler Listelendi.";
        public static string ProductAddedError="Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists="Aynı isimde ürün eklenemez.";
        public static string CheckIfCategoryCountError="15'ten fazla kategori var daha fazla ürün eklenemez.";
    }
}
