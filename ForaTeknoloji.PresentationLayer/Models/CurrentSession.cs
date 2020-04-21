using ForaTeknoloji.Entities.Entities;
using System.Web;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class CurrentSession
    {

        /// <summary>
        /// Sisteme giriş yapan kullanıcıyı gönderiyor.
        /// </summary>
        public static DBUsers User
        {
            get { return Get<DBUsers>("login"); }

        }


        public static OperatorTransactionList UserManagmentList
        {
            get { return Get<OperatorTransactionList>("loginUserList"); }
        }

        /// <summary>
        /// Session'da ki paneli gönderiyor.
        /// </summary>
        public static PanelSettings Panel
        {
            get { return Get<PanelSettings>("Panel"); }
        }

        /// <summary>
        /// Session'a nesne atama metodu
        /// </summary>
        /// <typeparam name="T">IEntity tipinden nesne</typeparam>
        /// <param name="key">Session anahtar kelimesi</param>
        /// <param name="obj">Session nesnesi</param>
        public static void Set<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
            HttpContext.Current.Session.Timeout = 90;
        }

        /// <summary>
        /// Session'da ki nesneyi gönderiyor.
        /// </summary>
        /// <typeparam name="T">IEntity tipinden nesne</typeparam>
        /// <param name="key">Session'da ki anahtar kelime</param>
        /// <returns></returns>
        public static T Get<T>(string key) where T : class, new()
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return HttpContext.Current.Session[key] as T;
            }

            return default(T);
        }

        /// <summary>
        /// Session'da ki nesneyi siliyor.
        /// </summary>
        /// <param name="key">Session'da ki anahtar kelimeye göre nesneyi siliyor.</param>
        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        /// <summary>
        /// Session'ı tamamen temizliyor.
        /// </summary>
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}