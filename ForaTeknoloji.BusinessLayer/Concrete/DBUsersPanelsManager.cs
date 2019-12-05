using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBUsersPanelsManager : IDBUsersPanelsService
    {
        private IDBUsersPanelsDal _dBUsersPanelsDal;
        public DBUsersPanelsManager(IDBUsersPanelsDal dBUsersPanelsDal)
        {
            _dBUsersPanelsDal = dBUsersPanelsDal;
        }
        public DBUsersPanels AddDBUsersPanels(DBUsersPanels dBUsersPanels)
        {
            return _dBUsersPanelsDal.Add(dBUsersPanels);
        }

        public void DeleteDBUsersPanels(DBUsersPanels dBUsersPanels)
        {
            _dBUsersPanelsDal.Delete(dBUsersPanels);
        }

        public List<DBUsersPanels> GetAllDBUsersPanels(Expression<Func<DBUsersPanels, bool>> filter = null)
        {
            return filter == null ? _dBUsersPanelsDal.GetList() : _dBUsersPanelsDal.GetList(filter);
        }

        public DBUsersPanels GetById(int id)
        {
            return _dBUsersPanelsDal.Get(x => x.Kayit_No == id);
        }

        public DBUsersPanels UpdateDBUsersPanels(DBUsersPanels dBUsersPanels)
        {
            return _dBUsersPanelsDal.Update(dBUsersPanels);
        }

        public void DeleteAllWithUserName(string UserName)
        {
            _dBUsersPanelsDal.DeleteAllWithUserName(UserName);
        }

    }
}
