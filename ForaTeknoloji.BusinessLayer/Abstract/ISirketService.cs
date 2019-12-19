using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ISirketService
    {
        List<Sirketler> GetAllSirketler(Expression<Func<Sirketler, bool>> filter = null);
        Sirketler GetById(int id);
        Sirketler AddSirket(Sirketler sirket);
        void DeleteSirket(Sirketler sirket);
        void DeleteAll();
        Sirketler UpdateSirket(Sirketler sirket);
        List<Sirketler> GetByKullaniciAdi(string kullaniciAdi);
        Sirketler GetBySirketAdi(string SirketAdi);
    }
}
