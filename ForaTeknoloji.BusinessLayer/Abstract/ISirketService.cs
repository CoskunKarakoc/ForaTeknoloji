using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ISirketService
    {
        List<Sirketler> GetAllSirketler();
        Sirketler GetById(int id);
        Sirketler AddSirket(Sirketler sirket);
        void DeleteSirket(Sirketler sirket);
        Sirketler UpdateSirket(Sirketler sirket);
    }
}
