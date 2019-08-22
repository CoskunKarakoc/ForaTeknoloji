using ForaTeknoloji.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail,int? GlobalBolgeNo, int? Daire, string Plaka = null);
    }
}
