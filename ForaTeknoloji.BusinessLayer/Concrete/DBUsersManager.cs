using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBUsersManager : IDBUsersService
    {
        private IDBUsersDal _dBUsersDal;
        public DBUsersManager(IDBUsersDal dBUsersDal)
        {
            _dBUsersDal = dBUsersDal;
        }
        public DBUsers AddDBUsers(DBUsers dBUsers)
        {
            if (dBUsers.Kullanici_Islemleri == null)
                dBUsers.Kullanici_Islemleri = 3;
            if (dBUsers.Grup_Islemleri == null)
                dBUsers.Grup_Islemleri = 3;
            if (dBUsers.Programli_Kapi_Islemleri == null)
                dBUsers.Programli_Kapi_Islemleri = 3;
            if (dBUsers.Gecis_Verileri_Rapor_Islemleri == null)
                dBUsers.Gecis_Verileri_Rapor_Islemleri = 3;
            if (dBUsers.Ziyaretci_Islemleri == null)
                dBUsers.Ziyaretci_Islemleri = 3;
            if (dBUsers.Canli_Izleme == null)
                dBUsers.Canli_Izleme = 3;
            if (dBUsers.Alarm_Islemleri == null)
                dBUsers.Alarm_Islemleri = 3;
            if (dBUsers.SysAdmin == null)
                dBUsers.SysAdmin = false;
            if (dBUsers.OtherDeviceReports == null)
                dBUsers.OtherDeviceReports = false;
            if (dBUsers.SysAdmin == true)
            {
                dBUsers.Kullanici_Islemleri = 1;
                dBUsers.Grup_Islemleri = 1;
                dBUsers.Programli_Kapi_Islemleri = 1;
                dBUsers.Gecis_Verileri_Rapor_Islemleri = 1;
                dBUsers.Ziyaretci_Islemleri = 1;
                dBUsers.Canli_Izleme = 1;
                dBUsers.Alarm_Islemleri = 1;
                dBUsers.OtherDeviceReports = true;
            }

            return _dBUsersDal.Add(dBUsers);
        }

        public void DeleteDBUsers(DBUsers dBUsers)
        {
            _dBUsersDal.Delete(dBUsers);
        }

        public List<DBUsers> GetAllDBUsers(Expression<Func<DBUsers, bool>> filter = null)
        {
            return filter == null ? _dBUsersDal.GetList() : _dBUsersDal.GetList(filter);
        }

        public DBUsers GetById(string kullaniciAdi)
        {
            return _dBUsersDal.Get(x => x.Kullanici_Adi == kullaniciAdi);
        }

        public DBUsers UpdateDBUsers(DBUsers dBUsers)
        {
            if (dBUsers.Kullanici_Islemleri == null)
                dBUsers.Kullanici_Islemleri = 3;
            if (dBUsers.Grup_Islemleri == null)
                dBUsers.Grup_Islemleri = 3;
            if (dBUsers.Programli_Kapi_Islemleri == null)
                dBUsers.Programli_Kapi_Islemleri = 3;
            if (dBUsers.Gecis_Verileri_Rapor_Islemleri == null)
                dBUsers.Gecis_Verileri_Rapor_Islemleri = 3;
            if (dBUsers.Ziyaretci_Islemleri == null)
                dBUsers.Ziyaretci_Islemleri = 3;
            if (dBUsers.Canli_Izleme == null)
                dBUsers.Canli_Izleme = 3;
            if (dBUsers.Alarm_Islemleri == null)
                dBUsers.Alarm_Islemleri = 3;
            if (dBUsers.SysAdmin == null)
                dBUsers.SysAdmin = false;
            if (dBUsers.OtherDeviceReports == null)
                dBUsers.OtherDeviceReports = false;
            if (dBUsers.SysAdmin == true)
            {
                dBUsers.Kullanici_Islemleri = 1;
                dBUsers.Grup_Islemleri = 1;
                dBUsers.Programli_Kapi_Islemleri = 1;
                dBUsers.Gecis_Verileri_Rapor_Islemleri = 1;
                dBUsers.Ziyaretci_Islemleri = 1;
                dBUsers.Canli_Izleme = 1;
                dBUsers.Alarm_Islemleri = 1;
                dBUsers.OtherDeviceReports = true;
            }


            return _dBUsersDal.Update(dBUsers);
        }


        public DBUsers LoginUsers(LoginViewModel model)
        {
            DBUsers user = _dBUsersDal.Get(x => x.Kullanici_Adi == model.Username && x.Sifre == model.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public DBUsers GetBySifre(string Sifre)
        {
            return _dBUsersDal.Get(x => x.Sifre == Sifre);
        }

        public DBUsers GetByEmailAdres(string EMailAdress)
        {
            return _dBUsersDal.Get(x => x.EMail == EMailAdress);
        }



    }
}
