using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDepartmanService
    {

        List<Departmanlar> GetAllDepartmanlar();
        Departmanlar GetById(int id);
        Departmanlar AddDepartman(Departmanlar departman);
        void DeleteDepartmanlar(Departmanlar departman);
        Departmanlar UpdateDepartman(Departmanlar departman);
        List<Departmanlar> GetByKullaniciAdi(string kullaniciAdi);
    }
}
