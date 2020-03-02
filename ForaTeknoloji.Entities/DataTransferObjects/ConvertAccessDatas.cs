using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.DataTransferObjects
{
    public static class ConvertAccessDatas
    {
        /// <summary>
        /// AccessDatas Nesnesini AccessDatasTemps Nesnesine Dönüştürüyor.
        /// </summary>
        /// <param name="accessDatas"></param>
        /// <returns></returns>
        public static AccessDatasTemp AccessDatasToAccessDatasTemp(AccessDatas accessDatas)
        {
            var accessDatasTemp = new AccessDatasTemp
            {
                ID = accessDatas.ID,
                Kart_ID = accessDatas.Kart_ID,
                Tarih = accessDatas.Tarih,
                Lokal_Bolge_No = accessDatas.Lokal_Bolge_No,
                Global_Bolge_No = accessDatas.Global_Bolge_No,
                Panel_ID = accessDatas.Panel_ID,
                Kapi_ID = accessDatas.Kapi_ID,
                Gecis_Tipi = accessDatas.Gecis_Tipi,
                Kod = accessDatas.Kod,
                Kullanici_Tipi = accessDatas.Kullanici_Tipi,
                Visitor_Kayit_No = accessDatas.Visitor_Kayit_No,
                User_Kayit_No = accessDatas.User_Kayit_No,
                Kontrol = accessDatas.Kontrol,
                Kontrol_Tarihi = accessDatas.Kontrol_Tarihi,
                Canli_Resim = accessDatas.Canli_Resim,
                Plaka = accessDatas.Plaka,
                Kullanici_Adi = accessDatas.Kullanici_Adi,
                Islem_Verisi_1 = accessDatas.Islem_Verisi_1,
                Islem_Verisi_2 = accessDatas.Islem_Verisi_2
            };
            return accessDatasTemp;
        }
    }
}
