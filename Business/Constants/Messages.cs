using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductInvalidName = "Ürün ismi geçersiz.";
        internal static string ProductListed = "Ürünler listelendi.";
        internal static string MaintenanceTime = "Sistem bakımda.";
        internal static string ProductCountOfCategoryError = "Bu kategoride en fazla 10 ürün olabilir.";
        internal static string ExistingProductName = "Bu isimde bir ürün bulunmakta, başka bir isim giriniz.";
        internal static string CategoryLimitExceeded = "Kategori limiti aşılmış olduğu için daha fazla ürün girişi yapılamaz.";
    }
}
