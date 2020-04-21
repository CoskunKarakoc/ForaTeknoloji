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
                                Kapi_16_Baglanti = d.Kapi_16_Baglanti
                            };
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }

    }



}
