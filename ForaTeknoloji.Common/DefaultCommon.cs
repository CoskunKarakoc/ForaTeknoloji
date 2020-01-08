namespace ForaTeknoloji.Common
{
    public class DefaultCommon : ICommon
    {

        /// <summary>
        /// Sistemde kullanıcı kayıtlı değilse default 'System' gelecek.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUsername()
        {
            return "system";
        }
    }
}
