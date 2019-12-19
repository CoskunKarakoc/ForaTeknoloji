using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class ChartController : Controller
    {
        private IReportService _reportService;
        private IUserService _userService;
        private IAccessDatasService _accessDatasService;
        DBUsers user;
        public ChartController(IReportService reportService, IUserService userService, IAccessDatasService accessDatasService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _userService = userService;
            _reportService = reportService;
            _accessDatasService = accessDatasService;

            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
        }




        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Count()
        {

            var countUser = new Count
            {
                Toplam_Kullanici = _userService.GetAllUsers().Where(x => x.Kullanici_Tipi != 1).ToList().Count,
                Icerdeki_Kullanici = _reportService.GelenGelmeyen_Gelenlers(null).Count,
                Disardaki_Kullanici = _reportService.GelenGelmeyen_Gelmeyens(null).Count,
                Pasif_Kullanici = 0,
                Gecis_Yapanlar = _accessDatasService.GetAllAccessDatas().Count,
                Ziyaretci = _reportService.GetIcerdeDısardaZiyaretci(null).Count

            };
            return Json(countUser, JsonRequestBehavior.AllowGet);
        }



    }
}