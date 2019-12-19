using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class BloklarManager : IBloklarService
    {
        private IBloklarDal _bloklarDal;
        public BloklarManager(IBloklarDal bloklarDal)
        {
            _bloklarDal = bloklarDal;
        }
        public Bloklar AddBloklar(Bloklar bloklar)
        {
            return _bloklarDal.Add(bloklar);
        }

        public void DeleteAll()
        {
            _bloklarDal.DeleteAll();
        }

        public void DeleteBloklar(Bloklar bloklar)
        {
            _bloklarDal.Delete(bloklar);
        }

        public List<Bloklar> GetAllBloklar()
        {
            return _bloklarDal.GetList();
        }

        public Bloklar GetByBlokAdi(string blokAdi)
        {
            return _bloklarDal.Get(x => x.Adi == blokAdi);
        }

        public Bloklar GetById(int id)
        {
            return _bloklarDal.Get(x => x.Blok_No == id);
        }

        public Bloklar UpdateBloklar(Bloklar bloklar)
        {
            return _bloklarDal.Update(bloklar);
        }
    }
}
