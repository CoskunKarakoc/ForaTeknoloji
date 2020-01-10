using ForaTeknoloji.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.DataTransferObjects
{
    public static class DoorOperationCode
    {
        /// <summary>
        /// Kapıların seçili olup olmadıklarına göre kod oluşturyor.
        /// Not:1001010100000 gibi.
        /// </summary>
        /// <param name="kapiOperasyon">Boolean tipte kapı durumları</param>
        /// <returns></returns>
        public static string CreateDoorOperationCode(KapiOperasyon kapiOperasyon)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (kapiOperasyon.Kapi_1 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_2 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_3 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_4 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_5 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_6 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_7 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_8 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_9 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_10 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_11 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_12 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_13 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_14 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_15 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Kapi_16 == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");
            if (kapiOperasyon.Alarm == true)
                stringBuilder.Append("1");
            else
                stringBuilder.Append("0");

            return stringBuilder.ToString();
        }

    }
}
