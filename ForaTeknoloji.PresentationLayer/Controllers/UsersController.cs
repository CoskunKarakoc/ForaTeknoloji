using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Excp]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private ISirketService _sirketService;
        private IGroupMasterService _groupMasterService;
        private IUserTypesService _userTypesService;
        private IBloklarService _bloklarService;
        public UsersController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupMasterService groupMasterService, IUserTypesService userTypesService,IBloklarService bloklarService)
        {
            _userService = userService;
            _departmanService = departmanService;
            _sirketService = sirketService;
            _groupMasterService = groupMasterService;
            _userTypesService = userTypesService;
            _bloklarService = bloklarService;
        }



        // GET: Users
        public ActionResult Index()
        {

            var model = new UsersListViewModel
            {
                Users = _userService.GetAllUsersWithOuther()
            };
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            ComplexUser complexUser = _userService.GetAllUsersWithOuther().FirstOrDefault(x=>x.ID==id);
            if (complexUser == null)
            {
                return HttpNotFound();
            }
            var model = new KullaniciListViewModelModel
            {
                ComplexUser = complexUser,
                Departmanlar = _departmanService.GetAllDepartmanlar().Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComplexUser complexUser)
        {
            if (ModelState.IsValid)
            {
                var User = _userService.GetAllUsersWithOuther().FirstOrDefault(x=>x.ID==complexUser.ID);
                if (User != null)
                {
                    Users users = new Users
                    {
                        ID = User.ID,
                        Kart_ID = User.Kart_ID,
                        Adi = User.Adi,
                        Soyadi = User.Soyadi,
                        Sirket_No = _sirketService.GetBySirketAdi(User.Sirket).Sirket_No,
                        Departman_No=_departmanService.GetByDepartmanAdi(User.Departman).Departman_No,
                        Blok_No=_bloklarService.GetByBlokAdi(User.Blok).Blok_No,
                        Plaka=User.Plaka,
                        Visitor_Grup_No=User.Ziyaretci_Grubu
                    };
                    _userService.UpdateUsers(users);
                    return RedirectToAction("Index");
                }
            }
            return View(complexUser);
        }






    }
}