using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Common
{
    public static class ReportParamatersDateAndTime
    {
        public static string ParametersDateAndTimeBindForReport(DateTime? Baslangis_Tarihi, DateTime? Bitis_Tarihi, DateTime? Baslangic_Saati, DateTime? Bitis_Saati)
        {
            string baslik = "";
            if (Baslangis_Tarihi != null)
                baslik += Baslangis_Tarihi.Value.ToShortDateString();
            else
                baslik += DateTime.Now.ToShortDateString();

            if (Baslangic_Saati != null)
                baslik += " " + Baslangic_Saati.Value.ToShortTimeString();
            else
                baslik += " 00:00";

            if (Bitis_Tarihi != null)
                baslik += " - " + Bitis_Tarihi.Value.ToShortDateString();

            if (Bitis_Saati != null)
                baslik += "  " + Bitis_Saati.Value.ToShortTimeString();
            else
                baslik += " 23:59";
            return baslik;
        }

        public static string ParametersDateAndTimeBindForReport(DateTime? Baslangis_Tarihi, DateTime? Bitis_Tarihi)
        {
            string baslik = "";
            if (Baslangis_Tarihi != null)
                baslik += Baslangis_Tarihi.Value.ToShortDateString();
            else
                baslik += DateTime.Now.ToShortDateString();

            baslik += " 00:00";

            if (Bitis_Tarihi != null)
                baslik += " - " + Bitis_Tarihi.Value.ToShortDateString();

            baslik += " 23:59";
            return baslik;
        }

        public static string ParametersDateAndTimeBindForReport(DateTime? Baslangis_Tarihi)
        {
            string baslik = "";
            if (Baslangis_Tarihi != null)
                baslik += Baslangis_Tarihi.Value.ToShortDateString();
            else
                baslik += DateTime.Now.ToShortDateString();

            return baslik;
        }




    }
}
