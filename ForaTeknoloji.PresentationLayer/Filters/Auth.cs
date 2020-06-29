using ForaTeknoloji.PresentationLayer.Models;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User == null || CurrentSession.UserManagmentList == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}