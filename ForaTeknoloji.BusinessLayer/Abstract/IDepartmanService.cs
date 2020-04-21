using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDepartmanService
    {

        List<Departmanlar> GetAllDepartmanlar(Expression<Func<Departmanlar, bool>> filter = null);
        Departmanlar GetById(int id);
        Departmanlar AddDepartman(Departmanlar departman);
        void DeleteDepartmanlar(Departmanlar departman);
        void DeleteAll();
        Departmanlar UpdateDepartman(Departmanlar departman);
        List<Departmanlar> GetByKullaniciAdi(string kullaniciAdi);
        Departmanlar GetByDepartmanAdi(string departmanAdi);
    }
}
