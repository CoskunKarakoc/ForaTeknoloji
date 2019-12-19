using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessDatasService
    {
        /// <summary>
        /// Liste halinde tüm 'AccessDatas' verilerini gönderiyor.
        /// </summary>
        /// <param name="filter">Lambda expression ile filtreleme yapılıyor.</param>
        /// <returns></returns>
        List<AccessDatas> GetAllAccessDatas(Expression<Func<AccessDatas, bool>> filter = null);
      
        /// <summary>
        /// Liste halinde 'AccessDatas' verilerini gönderiyor.
        /// </summary>
        /// <param name="id">AccessDatas ID parametresi ile koşul uygulanıyor.</param>
        /// <returns></returns>
        List<AccessDatas> GetById(int id);
       
        /// <summary>
        /// Liste halinde 'AccessDatas' verilerini gönderiyor.
        /// </summary>
        /// <param name="id">AccessDatas Kod parametresi ile koşul uygulanıyor.</param>
        /// <returns></returns>
        List<AccessDatas> GetByKod(int kod);
      
        /// <summary>
        /// Tek bir AccessDatas verisi gönderiyor.
        /// </summary>
        /// <param name="Kayit_No">AccessDatas Kayit No parametresi ile koşul uygulanıyor.</param>
        /// <returns></returns>
        AccessDatas GetByKayit_No(int Kayit_No);
      
        /// <summary>
        /// Liste halinde AccessDatas'ta ki geçiş tiplerini gönderiyor.
        /// </summary>
        /// <returns></returns>
        List<int?> GetGecisTipi();
      
        /// <summary>
        /// AccessDatas tablosuna kayıt yapıyor.
        /// </summary>
        /// <param name="accessDatas">AccessDatas nesnesi alıyor.</param>
        /// <returns></returns>
        AccessDatas AddAccessData(AccessDatas accessDatas);
       
        /// <summary>
        /// AccessDatas tablosundan kayıt siliyor.
        /// </summary>
        /// <param name="accessDatas">AccessDatas nesnesi alıyor.</param>
        void DeleteAccessData(AccessDatas accessDatas);
      
        /// <summary>
        /// AccessDatas tablosunda güncelleme yapıyor.
        /// </summary>
        /// <param name="accessDatas">AccessDatas nesnesi alıyor. Not: Kayit_No birincil anahtar değerine göre güncelleme yapıyor.</param>
        /// <returns></returns>
        AccessDatas UpdateAccessData(AccessDatas accessDatas);
       
        /// <summary>
        /// Lambda expression değerine göre geriye tek bir tane 'AccessDatas' gönderiyor.
        /// </summary>
        /// <param name="filter">Lambda expression filtreleme parametresi</param>
        /// <returns></returns>
        AccessDatas GetByQuery(Expression<Func<AccessDatas, bool>> filter = null);
      
        /// <summary>
        /// IQueryable formatta dönen listeye koşul uygulanarak sorgu execute ediliyor.
        /// </summary>
        /// <param name="filter">Sorguya uygulanacak Lambda expression filtereleme parametresi</param>
        /// <returns></returns>
        IQueryable<AccessDatas> GetByQueryable(Expression<Func<AccessDatas, bool>> filter = null);
    }
}
