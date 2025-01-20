using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    // static verdiginde onu newlemiyorsun direkt kullaniyorsun 
    public static class Messages 
    {
        public static string ProductAdded = "Ürün eklendi"; // publicler pascal case, private olsaydı camel case
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        internal static string ProductnameAlreadtExists = "Bu isimde zaten başka bir ürün var";
        internal static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string? AuthorizationDenied = "Bu yetki alanına sahip değilsiniz";
        internal static string UserRegistered = "Başarıyla kayıt olundu";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "Şifre hatalı";
        internal static string SuccessfulLogin = "Giriş başarılı";
        internal static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        internal static string AccessTokenCreated = "Erişim tokenı oluşturuldu";
    }
}
