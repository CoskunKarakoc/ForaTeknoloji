using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDepartmanService
    {

        List<Departmanlar> GetAllDepartmanlar();
        Departmanlar GetById(int id);
        Departmanlar AddDepartman(Departmanlar departman);
        void DeleteDepartmanlar(Departmanlar departman);
        void DeleteAll();
        Departmanlar UpdateDepartman(Departmanlar departman);
        List<Departmanlar> GetByKullaniciAdi(string kullaniciAdi);
        Departmanlar GetByDepartmanAdi(string departmanAdi);
    }
}
