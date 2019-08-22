using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AccessDatasManager : IAccessDatasService
    {
        private IAccessDatasDal _accessDatasDal;
        public AccessDatasManager(IAccessDatasDal accessDatasDal)
        {
            _accessDatasDal = accessDatasDal;
        }
        public AccessDatas AddAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Add(accessDatas);
        }

        public void DeleteAccessData(AccessDatas accessDatas)
        {
            _accessDatasDal.Delete(accessDatas);
        }

        public List<AccessDatas> GetAllAccessDatas()
        {
            return _accessDatasDal.GetList();
        }

        public AccessDatas GetById(int id)
        {
            return _accessDatasDal.Get(x => x.Kayit_No == id);
        }

        public AccessDatas UpdateAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Update(accessDatas);
        }

        public List<AccessDatas> GetByKod(int kod)
        {
            return _accessDatasDal.GetList(x => x.Kod == kod);
        }
        public List<int?> GetGecisTipi()
        {
            return _accessDatasDal.GetList().Select(x => x.Gecis_Tipi).ToList();
        }

        public List<AccessDatas> GetTanimsizListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1,DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2,string KapiYon)
        {
            //deneme
            GetDigerGecisListesi(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null);
            //deneme
            var liste = _accessDatasDal.GetTanimsizListesi();
            if (Panel != null)
            {
                liste = liste.Where(x => x.Panel_ID == Panel);
            }
            if (Kapi1 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 1);

            }
            if (Kapi2 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 2);
            }
            if (Kapi3 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 3);
            }
            if (Kapi4 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 4);
            }
            if (Kapi5!=null)
            {
                liste = liste.Where(x => x.Kapi_ID == 5);
            }
            if (Kapi6 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 6);
            }
            if (Kapi7 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 7);
            }
            if (Kapi8 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 8);
            }
            if (KapiYon== "giris")
            {
                liste = liste.Where(x => x.Gecis_Tipi == 0);
            }
            if (KapiYon=="cikis")
            {
                liste = liste.Where(x => x.Gecis_Tipi == 1);
            }
            if (Tarih1!=null)
            {
                liste = liste.Where(x => x.Tarih >= Tarih1);
            }
            if (Tarih1 !=null && Tarih2 !=null)
            {
                liste = liste.Where(x => x.Tarih >= Tarih1 && x.Tarih <= Tarih2);  
            }
            if (Saat1!=null)
            {
                liste = liste.Where(x => x.Tarih >= Saat1);
            }
            if (Saat1!=null && Saat2!=null)
            {
                liste = liste.Where(x => x.Tarih >= Saat1 && x.Tarih <= Saat2);
            }
            return liste.OrderByDescending(x=>x.Kayit_No).ToList();
        }

        public List<DigerGecisRaporList> GetDigerGecisListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon)
        {
            var liste = _accessDatasDal.GetDigerGecisListesi();
           if (Kapi1!=null)
            {
                liste = liste.Where(x => x.Kapi_ID==1);
            }
            if (Kapi2 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 2);
            }
            if (Kapi3 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 3);
            }
            if (Kapi4 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 4);
            }
            if (Kapi5 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 5);
            }
            if (Kapi6 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 6);
            }
            if (Kapi7 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 7);
            }
            if (Kapi8 != null)
            {
                liste = liste.Where(x => x.Kapi_ID == 8);
            }
            if (Paneller!=null)
            {
                liste = liste.Where(x => x.Panel_ID == Paneller);
            }
            if (KapiYon=="giris")
            {
                liste = liste.Where(x => x.Gecis_Tipi == 0);
            }
            if (KapiYon=="cikis")
            {
                liste = liste.Where(x => x.Gecis_Tipi == 1);
            }
            if (Tetikleme== "OTetikleme")
            {
                liste = liste.Where(x => x.TKod==5);
            }
            if (Tetikleme== "OAcma")
            {
                liste = liste.Where(x => x.TKod==6);
            }
            if (Tetikleme == "OKapatma")
            {
                liste = liste.Where(x => x.TKod==7);
            }
            if (Tetikleme == "OSerbest")
            {
                liste = liste.Where(x => x.TKod==13);
            }
            if (Tetikleme == "BTetikleme")
            {
                liste = liste.Where(x => x.TKod==8);
            }
            if (Tetikleme == "PAcma")
            {
                liste = liste.Where(x => x.TKod==9);
            }
            if (Tetikleme == "PKapatma")
            {
                liste = liste.Where(x => x.TKod==10);
            }
            if (Tetikleme == "PSerbest")
            {
                liste = liste.Where(x => x.TKod==14);
            }
            if (Tetikleme == "Alarm")
            {
                liste = liste.Where(x => x.TKod==20);
            }
            if (Tetikleme == "Yangin")
            {
                liste = liste.Where(x => x.TKod==21);
            }
            if (Tetikleme== "KAlarm")
            {
                liste = liste.Where(x => x.TKod==22 || x.TKod==23 || x.TKod==24);
            }
            var sonuc = liste.ToList();
            return sonuc;
        }
    }
}
