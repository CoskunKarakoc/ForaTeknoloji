using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System.Web.Mvc;
//TODO:Satırlara tıklanıldığında data attributeları alınacak
namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Excp]
    public class HomeController : Controller
    {
        private IDBUsersService _dBUsersService;
        public HomeController(IDBUsersService dBUsersService)
        {
            _dBUsersService = dBUsersService;

        }

        [Auth]
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        //GET:Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                DBUsers user = _dBUsersService.LoginUsers(login);
                if (user == null)
                {
                    ModelState.AddModelError("", "Tanımsız Kullanıcı Girişi!");
                    return View(login);
                }
                CurrentSession.Set<DBUsers>("login", user);//Session'a bilgi saklama
                return RedirectToAction("Index", "Home");

            }
            return View(login);
        }
        //Çıkış Action'u
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult HassError()
        {
            return View();

        }

    }
}