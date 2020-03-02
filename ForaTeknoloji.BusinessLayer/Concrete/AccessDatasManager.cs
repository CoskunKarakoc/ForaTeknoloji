using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AccessDatasManager : IAccessDatasService
    {
        private IAccessDatasDal _accessDatasDal;
        private IAccessDatasTempDal _accessDatasTempDal;
        private IProgInitDal _progInitDal;
        public AccessDatasManager(IAccessDatasDal accessDatasDal, IAccessDatasTempDal accessDatasTempDal, IProgInitDal progInitDal)
        {
            _accessDatasDal = accessDatasDal;
            _accessDatasTempDal = accessDatasTempDal;
            _progInitDal = progInitDal;
        }

        public AccessDatas AddAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Add(accessDatas);
        }

        public void DeleteAccessData(AccessDatas accessDatas)
        {
            _accessDatasDal.Delete(accessDatas);
        }

        public List<AccessDatas> GetAllAccessDatas(Expression<Func<AccessDatas, bool>> filter = null)
        {
            return filter == null ? _accessDatasDal.GetList() : _accessDatasDal.GetList(filter);
        }

        public List<AccessDatas> GetById(int id)
        {
            return _accessDatasDal.GetList(x => x.ID == id);
        }

        public AccessDatas GetByKayit_No(int Kayit_No)
        {
            return _accessDatasDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public AccessDatas UpdateAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Update(accessDatas);
        }

        public List<AccessDatas> GetByKod(int kod)
        {
            return _accessDatasDal.GetList(x => x.Kod == kod);
        }

        public List<int?> GetGecisTipi()
        {
            return _accessDatasDal.GetList().Select(x => x.Gecis_Tipi).ToList();
        }

        public AccessDatas GetByQuery(Expression<Func<AccessDatas, bool>> filter = null)
        {
            return filter == null ? null : _accessDatasDal.Get(filter);
        }

        public IQueryable<AccessDatas> GetByQueryable(Expression<Func<AccessDatas, bool>> filter = null)
        {
            return _accessDatasDal.Queryable();
        }

        public bool AddOperatorLog(int? LogType, string UserName, int? Veri1, int? Veri2, int? Panel, int? Kapi)
        {
            var progInit = _progInitDal.GetList().FirstOrDefault();
            var result = false;
            if (LogType >= 100 && LogType <= 109)
            {
                if (progInit.NoOpLogUser == true)
                    result = true;
            }
            else if (LogType >= 110 && LogType <= 119)
            {
                if (progInit.NoOpLogTimeZone == true)
                    result = true;
            }
            else if (LogType >= 120 && LogType <= 129)
            {
                if (progInit.NoOpLogGroup == true)
                    result = true;
            }
            else if (LogType >= 130 && LogType <= 139)
            {
                if (progInit.NoOpPanelSettings == true)
                    result = true;
            }
            else if (LogType >= 140 && LogType <= 149)
            {
                if (progInit.NoOpLogUserAlarm == true)
                    result = true;
            }
            else if (LogType >= 150 && LogType <= 159)
            {
                if (progInit.NoOpLogCamera == true)
                    result = true;
            }
            else if (LogType >= 160 && LogType <= 169)
            {
                if (progInit.NoOpLogLift == true)
                    result = true;
            }
            else if (LogType >= 170 && LogType <= 179)
            {
                if (progInit.NoOpLogProgrammedRelay == true)
                    result = true;
            }
            else if (LogType >= 180 && LogType <= 189)
            {
                if (progInit.NoOpLogCompany == true)
                    result = true;
            }
            else if (LogType >= 190 && LogType <= 199)
            {
                if (progInit.NoOpLogDepartment == true)
                    result = true;
            }
            else if (LogType >= 200 && LogType <= 209)
            {
                if (progInit.NoOpLogBlock == true)
                    result = true;
            }
            else if (LogType >= 210 && LogType <= 219)
            {
                if (progInit.NoOpLogImport == true)
                    result = true;
            }
            else if (LogType >= 220 && LogType <= 229)
            {
                if (progInit.NoOpLogEmailSMS == true)
                    result = true;
            }
            else if (LogType >= 230 && LogType <= 239)
            {

            }
            else if (LogType >= 240 && LogType <= 249)
            {
                if (progInit.NoOpLogUserGlobalInterlock == true)
                    result = true;
            }
            else if (LogType >= 250 && LogType <= 259)
            {
                if (progInit.NoOpLogGroupCalendar == true)
                    result = true;
            }
            else if (LogType >= 260 && LogType <= 269)
            {

            }
            else if (LogType >= 270 && LogType <= 299)
            {
                if (progInit.NoOpLogReports == true)
                    result = true;
            }
            else if (LogType >= 300 && LogType <= 309)
            {
                if (progInit.NoOpLogDatabase == true)
                    result = true;
            }
            else if (LogType >= 310 && LogType <= 319)
            {
                if (progInit.NoOpLogPanelLogs == true)
                    result = true;
            }
            else if (LogType >= 320 && LogType <= 329)
            {
                if (progInit.NoOpLogVisitor == true)
                    result = true;
            }
            else
            {
                if (progInit.NoOpOther == true)
                    result = true;
            }

            if (result == false)
            {
                var access = _accessDatasDal.GetList().FirstOrDefault(x => x.Panel_ID == Panel && x.Kapi_ID == Kapi);
                int? _global_bolge_no = null;
                int? _lokal_bolge_no = null;
                if (access != null)
                {
                    _global_bolge_no = access.Global_Bolge_No == null ? null : access.Global_Bolge_No;
                    _lokal_bolge_no = access.Lokal_Bolge_No == null ? null : access.Lokal_Bolge_No;
                }

                var nesne = new AccessDatas
                {
                    ID = 0,
                    Kart_ID = "0",
                    Kod = LogType,
                    Kullanici_Adi = UserName.Trim(),
                    Islem_Verisi_1 = (int)Veri1,
                    Islem_Verisi_2 = (int)Veri2,
                    Panel_ID = Panel,
                    Kapi_ID = Kapi,
                    Global_Bolge_No = _global_bolge_no,
                    Lokal_Bolge_No = _lokal_bolge_no,
                    Tarih = DateTime.Now,
                    Kontrol = 0,
                    Kullanici_Tipi = 0,
                    Gecis_Tipi = 0,
                    Plaka = "",
                };
                var entity = _accessDatasDal.Add(nesne);
                if (entity != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }



        }


        /// <summary>
        /// Güncel AccessDatas Verilerini AccessDatasTemp Tablosuna Kaydeder ve Kaydettiği Veriyi Kendinden Siler
        /// </summary>
        public void BackupAccessDatasTable()
        {
            _accessDatasDal.BackupAccessDatasTable();
        }

        /// <summary>
        /// Tüm AccessDatas Tablosunu Siler.
        /// Not:Kayit No Kaldığı Yerden Devam Eder.
        /// </summary>
        public void DeleteAllAccessDatas()
        {
            _accessDatasDal.DeleteAll();
        }

    }
}
