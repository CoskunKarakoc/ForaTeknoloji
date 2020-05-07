/*Bismillahirrahmanirrahim*/
using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace ForaTeknoloji.PresentationLayer.Controllers
{

    [Excp]
    public class HomeController : Controller
    {
        private IDBUsersService _dBUsersService;
        private IOperatorTransactionListService _operatorTransactionListService;
        private IEmailSettingsService _emailSettingsService;
        public HomeController(IDBUsersService dBUsersService, IOperatorTransactionListService operatorTransactionListService, IEmailSettingsService emailSettingsService)
        {
            _emailSettingsService = emailSettingsService;
            _dBUsersService = dBUsersService;
            _operatorTransactionListService = operatorTransactionListService;
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
                OperatorTransactionList oprtrList = _operatorTransactionListService.GetByKullaniciAdi(user.Kullanici_Adi);
                CurrentSession.Set<DBUsers>("login", user);//Session'a bilgi saklama
                CurrentSession.Set<OperatorTransactionList>("loginUserList", oprtrList);//Session'a bilgi saklama
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


        public ActionResult Orientation()
        {
            return View();
        }

        public ActionResult RecoverPassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RecoverPassword(string eMailAdress)
        {
            var checkUser = _dBUsersService.GetByEmailAdres(eMailAdress);
            var eMailSetting = _emailSettingsService.GetAllEMailSetting().FirstOrDefault();

            if (checkUser == null)
            {
                ModelState.AddModelError("", "Sistemde bu mail adresi ile kayıtlı kullanıcı bulunamadı!");
            }
            else
            {
                checkUser.Sifre = RandomPassword();
                var updatedUser = _dBUsersService.UpdateDBUsers(checkUser);
                string body = $"<p>Sisteme Giriş Yapabilmeniz İçin Kullanıcı Adı: <b>{updatedUser.Kullanici_Adi}</b> ve Şifreniz: <b>{updatedUser.Sifre}</b></p>";
                MailHelper.SendMail(body, updatedUser.EMail, "Şifre Kurtarma", eMailSetting.Kullanici_Adi);
                return RedirectToAction("Login", "Home");
            }
            return View();
        }


        public string RandomPassword()
        {
            Random Rnd = new Random();
            StringBuilder StrBuild = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                int ASCII = Rnd.Next(97, 123);
                char Karakter = Convert.ToChar(ASCII);
                StrBuild.Append(Karakter);
            }
            return StrBuild.ToString();
        }

    }
}