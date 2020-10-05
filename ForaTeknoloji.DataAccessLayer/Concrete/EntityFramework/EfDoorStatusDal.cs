using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDoorStatusDal : EfEntityRepositoryBase<DoorStatus, ForaContext>, IDoorStatusDal
    {

        public List<ComplexDoorStatus> ComplexDoorStatus(Expression<Func<ComplexDoorStatus, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from d in context.DoorStatuses
                            join p in context.PanelSettings
                            on d.Panel_ID equals p.Panel_ID
                            select new ComplexDoorStatus
                            {
                                Panel_ID = d.Panel_ID,
                                Panel_Name = p.Panel_Name,
                                Kapi_1_Baglanti = d.Kapi_1_Baglanti,
                                Kapi_2_Baglanti = d.Kapi_2_Baglanti,
                                Kapi_3_Baglanti = d.Kapi_3_Baglanti,
                                Kapi_4_Baglanti = d.Kapi_4_Baglanti,
                                Kapi_5_Baglanti = d.Kapi_5_Baglanti,
                                Kapi_6_Baglanti = d.Kapi_6_Baglanti,
                                Kapi_7_Baglanti = d.Kapi_7_Baglanti,
                                Kapi_8_Baglanti = d.Kapi_8_Baglanti,
                                Kapi_9_Baglanti = d.Kapi_9_Baglanti,
                                Kapi_10_Baglanti = d.Kapi_10_Baglanti,
                                Kapi_11_Baglanti = d.Kapi_11_Baglanti,
                                Kapi_12_Baglanti = d.Kapi_12_Baglanti,
                                Kapi_13_Baglanti = d.Kapi_13_Baglanti,
                                Kapi_14_Baglanti = d.Kapi_14_Baglanti,
                                Kapi_15_Baglanti = d.Kapi_15_Baglanti,
                                Kapi_16_Baglanti = d.Kapi_16_Baglanti,
                                Kapi_1_Sensor = d.Kapi_1_Sensor,
                                Kapi_2_Sensor = d.Kapi_2_Sensor,
                                Kapi_3_Sensor = d.Kapi_3_Sensor,
                                Kapi_4_Sensor = d.Kapi_4_Sensor,
                                Kapi_5_Sensor = d.Kapi_5_Sensor,
                                Kapi_6_Sensor = d.Kapi_6_Sensor,
                                Kapi_7_Sensor = d.Kapi_7_Sensor,
                                Kapi_8_Sensor = d.Kapi_8_Sensor,
                                Kapi_9_Sensor = d.Kapi_9_Sensor,
                                Kapi_10_Sensor = d.Kapi_10_Sensor,
                                Kapi_11_Sensor = d.Kapi_11_Sensor,
                                Kapi_12_Sensor = d.Kapi_12_Sensor,
                                Kapi_13_Sensor = d.Kapi_13_Sensor,
                                Kapi_14_Sensor = d.Kapi_14_Sensor,
                                Kapi_15_Sensor = d.Kapi_15_Sensor,
                                Kapi_16_Sensor = d.Kapi_16_Sensor,
                                Kapi_1_Button = d.Kapi_1_Button,
                                Kapi_2_Button = d.Kapi_2_Button,
                                Kapi_3_Button = d.Kapi_3_Button,
                                Kapi_4_Button = d.Kapi_4_Button,
                                Kapi_5_Button = d.Kapi_5_Button,
                                Kapi_6_Button = d.Kapi_6_Button,
                                Kapi_7_Button = d.Kapi_7_Button,
                                Kapi_8_Button = d.Kapi_8_Button,
                                Kapi_9_Button = d.Kapi_9_Button,
                                Kapi_10_Button = d.Kapi_10_Button,
                                Kapi_11_Button = d.Kapi_11_Button,
                                Kapi_12_Button = d.Kapi_12_Button,
                                Kapi_13_Button = d.Kapi_13_Button,
                                Kapi_14_Button = d.Kapi_14_Button,
                                Kapi_15_Button = d.Kapi_15_Button,
                                Kapi_16_Button = d.Kapi_16_Button

                            };
                return filter == null ? query.OrderBy(x => x.Panel_ID).ToList() : query.Where(filter).OrderBy(x => x.Panel_ID).ToList();
            }
        }

    }



}
