using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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