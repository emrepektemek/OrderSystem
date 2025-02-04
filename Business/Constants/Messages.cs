using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
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
        internal static string UserAlreadyExists = "Bu Email sistemde kayıtlıdır";
        internal static string AccessTokenCreated = "Giriş Yapıldı";
        internal static string CreatedUserOperationClaim = "Kullanıcıya rol atandı";
        internal static string UpdatedUserOperationClaim = "Kullanıcının rolü düzenlendi";
        internal static string DeleteddUserOperationClaim = "Kullanıcının rolü silindi";
        internal static string CreatedCustomer = "Customer oluşturuldu";
        internal static string CategoryNotExist = "Bu Category veri tabanında bulunmuyor";
    }
}
