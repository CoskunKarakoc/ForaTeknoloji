using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private ISirketDal _sirketDal;
        private IBloklarDal _bloklarDal;
        private IGroupsDetailDal _groupsDetailDal;
        private IDepartmanDal _departmanDal;
        private IGlobalZoneDal _globalZoneDal;

        public UserManager(IUserDal userDal, ISirketDal sirketDal, IBloklarDal bloklarDal, IGroupsDetailDal groupsDetailDal, IDepartmanDal departmanDal, IGlobalZoneDal globalZoneDal)
        {
            _userDal = userDal;
            _sirketDal = sirketDal;
            _bloklarDal = bloklarDal;
            _groupsDetailDal = groupsDetailDal;
            _departmanDal = departmanDal;
            _globalZoneDal = globalZoneDal;
        }
     
        public List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail, int? GlobalBolgeNo, int? Daire, string Plaka = null)
        {
         
            var list = _userDal.GetComplexPersonelList();
            var SirketAdi = _sirketDal.Get(x => x.Sirket_No == Sirketler);
            var DepartmanAdi = _departmanDal.Get(x => x.Departman_No == Departmanlar);
            var Blok = _bloklarDal.Get(x => x.Blok_No == Bloklar);
            var GroupDetail = _groupsDetailDal.Get(x => x.Kayit_No == Groupsdetail);
            var GlobalZone = _globalZoneDal.Get(x => x.Global_Bolge_No == GlobalBolgeNo);
            if (Daire != null)
            {
                list = list.Where(x => x.Daire == Daire);
            }
            if (DepartmanAdi != null)
            {
                list = list.Where(x => x.DepartmanAdi == DepartmanAdi.Adi);

            }
            if (Blok != null)
            {
                list = list.Where(x => x.BlokAdi == Blok.Adi);
            }
            if (Plaka != null && Plaka != "")
            {
                list = list.Where(x => x.Plaka == Plaka);
            }
            if (GroupDetail != null)
            {
                list = list.Where(x => x.Grup_Adi == GroupDetail.Grup_Adi);
            }
            if (GlobalBolgeNo != null)
            {
               

                list = list.Where(x => 
                    x.Kapi1_Global_Bolge_No == GlobalZone.Global_Bolge_No 
                || x.Kapi2_Global_Bolge_No==GlobalZone.Global_Bolge_No
                || x.Kapi3_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi4_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi5_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi6_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi7_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi8_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi9_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi10_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi11_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi12_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi13_Global_Bolge_No == GlobalZone.Global_Bolge_No 
                || x.Kapi14_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi15_Global_Bolge_No == GlobalZone.Global_Bolge_No
                || x.Kapi16_Global_Bolge_No == GlobalZone.Global_Bolge_No
                );
            }
            
            return list.ToList();
        }

    }
}
