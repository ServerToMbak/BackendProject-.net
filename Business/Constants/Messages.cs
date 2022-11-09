using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CategoryAdded = "kategori Eklendi";

        public static string CommentUpdated = "Yorum Güncellendi";

        public static string CommentDeleted = "Yorum Silindi";
        public static string CommentAdded = "Yorum Eklendi";
        public static string QuestionAdded = "SoruEklendi";
        public static string QuestionDeletted = "Soru Silindi";
        public static string QuestionUpdated = "Soru Güncellendi";

        public static string ImagesPath = "wwwroot\\Uploads\\Images\\";

        public static string UserRegistered = "Kullacı Kaydoldu";
        public static string UserNotFound = "Kullanıcı Bulumanadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";

        public static string AuthorizationDenied = "giriş engellendi";
        internal static string CategoryAlreadyExist="Aynı isimde birden fazla kategori eklenemez";
    }
}
