using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;

namespace ForaTeknoloji.PresentationLayer.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            DBUsers user = CurrentSession.User;
            if (user != null)
            {
                return user.Kullanici_Adi;
            }
            return "System";
        }
    }
}