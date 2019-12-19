using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IBloklarService
    {
        List<Bloklar> GetAllBloklar();
        Bloklar GetById(int id);
        Bloklar AddBloklar(Bloklar bloklar);
        void DeleteBloklar(Bloklar bloklar);
        void DeleteAll();
        Bloklar UpdateBloklar(Bloklar bloklar);
        Bloklar GetByBlokAdi(string blokAdi);
    }
}
