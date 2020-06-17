using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Users AddUsers(Users users)
        {
            if (users.Sirket_No == null)
                users.Sirket_No = 1;
            if (users.Departman_No == null)
                users.Departman_No = 1;
            if (users.Alt_Departman_No == null)
                users.Alt_Departman_No = 1;
            if (users.Kullanici_Tipi == null)
                users.Kullanici_Tipi = 0;

            return _userDal.Add(users);
        }

        public string AddUserWithCheckCardId(Users users)
        {
            string result = "";
            //Kart ID'sinin Tüm Kartlarda Sorgulanması
            if (users.Kart_ID != null && users.Kart_ID != "" && users.Kart_ID != "0")
            {
                var findUserKart1 = _userDal.Get(x => x.Kart_ID == users.Kart_ID || x.Kart_ID_2 == users.Kart_ID || x.Kart_ID_3 == users.Kart_ID);
                if (findUserKart1 != null)
                {
                    result = "Eklemek İstediğiniz Kullanıcının Kart ID'sini " + findUserKart1.Adi + " " + findUserKart1.Soyadi + " Adlı Kişi kullanıyor!";
                }
            }
            //Kart ID 2'nin Tüm Kartlarda Sorgulanması
            if (users.Kart_ID_2 != null && users.Kart_ID_2 != "" && users.Kart_ID_2 != "0")
            {
                var findUserKart2 = _userDal.Get(x => x.Kart_ID == users.Kart_ID_2 || x.Kart_ID_2 == users.Kart_ID_2 || x.Kart_ID_3 == users.Kart_ID_2);
                if (findUserKart2 != null)
                {
                    result = "Eklemek İstediğiniz Kullanıcının Kart ID 2'sini " + findUserKart2.Adi + " " + findUserKart2.Soyadi + " Adlı Kişi kullanıyor!";
                }
            }
            //Kart ID 3'ün Tüm Kartlarda Sorgulanması
            if (users.Kart_ID_3 != null && users.Kart_ID_3 != "" && users.Kart_ID_3 != "0")
            {
                var findUserKart3 = _userDal.Get(x => x.Kart_ID == users.Kart_ID_3 || x.Kart_ID_2 == users.Kart_ID_3 || x.Kart_ID_3 == users.Kart_ID_3);
                if (findUserKart3 != null)
                {
                    result = "Eklemek İstediğiniz Kullanıcının Kart ID 3'ünü " + findUserKart3.Adi + " " + findUserKart3.Soyadi + " Adlı Kişi kullanıyor!";
                }
            }
            if (result == "")
            {
                if (users.Sirket_No == null)
                    users.Sirket_No = 1;
                if (users.Departman_No == null)
                    users.Departman_No = 1;
                if (users.Alt_Departman_No == null)
                    users.Alt_Departman_No = 1;
                if (users.Kullanici_Tipi == null)
                    users.Kullanici_Tipi = 0;

                _userDal.Add(users);

                return "";
            }
            else
            {
                return result;
            }
        }

        public string UpdateWithCheckCardId(Users users)
        {
            string result = "";
            //Kart ID'sinin Kendi Hariç Tüm Kartlarda Sorgulanması
            if (users.Kart_ID != null && users.Kart_ID != "" && users.Kart_ID != "0")
            {
                var findUserKart1 = _userDal.Get(x => x.ID != users.ID && (x.Kart_ID == users.Kart_ID || x.Kart_ID_2 == users.Kart_ID || x.Kart_ID_3 == users.Kart_ID));
                if (findUserKart1 != null)
                {
                    result = "Güncellemek İstediğiniz Kullanıcının Kart ID'sini " + findUserKart1.Adi + " " + findUserKart1.Soyadi + " Adlı Kişi kullanıyor!";
                }
            }
            //Kart ID 2'nin Kendi Hariç Tüm Kartlarda Sorgulanması
            if (users.Kart_ID_2 != null && users.Kart_ID_2 != "" && users.Kart_ID_2 != "0")
            {
                var findUserKart2 = _userDal.Get(x => x.ID != users.ID && (x.Kart_ID == users.Kart_ID_2 || x.Kart_ID_2 == users.Kart_ID_2 || x.Kart_ID_3 == users.Kart_ID_2));
                if (findUserKart2 != null)
                {
                    result = "Güncellemek İstediğiniz Kullanıcının Kart ID 2'sini " + findUserKart2.Adi + " " + findUserKart2.Soyadi + " Adlı Kişi kullanıyor!";
                }
            }
            //Kart ID 3'ün Kendi Hariç Tüm Kartlarda Sorgulanması
            if (users.Kart_ID_3 != null && users.Kart_ID_3 != "" && users.Kart_ID_3 != "0")
            {
                var findUserKart3 = _userDal.Get(x => x.ID != users.ID && (x.Kart_ID == users.Kart_ID_3 || x.Kart_ID_2 == users.Kart_ID_3 || x.Kart_ID_3 == users.Kart_ID_3));
                if (findUserKart3 != null)
                {
                    result = "Güncellemek İstediğiniz Kullanıcının Kart ID 3'ünü " + findUserKart3.Adi + " " + findUserKart3.Soyadi + " Adlı Kişi kullanıyor!";
                }
            }

            if (result == "")
            {
                if (users.Sirket_No == null)
                    users.Sirket_No = 1;
                if (users.Departman_No == null)
                    users.Departman_No = 1;
                if (users.Kullanici_Tipi == null)
                    users.Kullanici_Tipi = 0;

                _userDal.Update(users);

                return "";
            }
            else
            {
                return result;
            }


        }


        public void DeleteUsers(Users users)
        {
            _userDal.Delete(users);
        }

        public List<Users> GetAllUsers(Expression<Func<Users, bool>> filter = null)
        {
            return filter == null ? _userDal.GetList() : _userDal.GetList(filter);
        }

        public Users GetById(int id)
        {
            return _userDal.Get(x => x.ID == id);
        }

        public Users UpdateUsers(Users users)
        {
            if (users.Sirket_No == null)
                users.Sirket_No = 1;
            if (users.Departman_No == null)
                users.Departman_No = 1;
            if (users.Kullanici_Tipi == null)
                users.Kullanici_Tipi = 0;

            return _userDal.Update(users);
        }

        public List<ComplexUser> GetAllUsersWithOuther(Expression<Func<ComplexUser, bool>> filter = null)
        {

            return filter == null ? _userDal.GetAllUsersWithOuther() : _userDal.GetAllUsersWithOuther(filter);
        }

        public Users GetByKayitNo(int? Kayit_No)
        {
            return _userDal.Get(x => x.Kayit_No == Kayit_No);
        }


        public void DeleteAllUsers()
        {
            _userDal.DeleteAllUsers();
        }

        public List<ComplexUser> GetAllUsersWithOutherOnlyUser(Expression<Func<ComplexUser, bool>> filter = null)
        {
            return filter == null ? _userDal.GetAllUsersWithOutherOnlyUser() : _userDal.GetAllUsersWithOutherOnlyUser(filter);
        }

        public bool FastGroupAdd(FastGroupParameters parameters)
        {
            bool result = false;
            if (parameters.Unvan_No != null && parameters.User_Grup != null && parameters.Grup_No != null)
            {
                foreach (var user in _userDal.GetList(x => x.Unvan_No == parameters.Unvan_No))
                {
                    if (parameters.User_Grup == 1)
                    {
                        user.Grup_No = parameters.Grup_No;
                        if (user.Sirket_No == null)
                            user.Sirket_No = 1;
                        if (user.Departman_No == null)
                            user.Departman_No = 1;
                        _userDal.Update(user);
                        result = true;
                    }
                    else if (parameters.User_Grup == 2)
                    {
                        user.Grup_No_1 = parameters.Grup_No;
                        if (user.Sirket_No == null)
                            user.Sirket_No = 1;
                        if (user.Departman_No == null)
                            user.Departman_No = 1;
                        _userDal.Update(user);
                        result = true;
                    }
                    else if (parameters.User_Grup == 3)
                    {
                        user.Grup_No_2 = parameters.Grup_No;
                        if (user.Sirket_No == null)
                            user.Sirket_No = 1;
                        if (user.Departman_No == null)
                            user.Departman_No = 1;
                        _userDal.Update(user);
                        result = true;
                    }
                    else if (parameters.User_Grup == 4)
                    {
                        user.Grup_No_3 = parameters.Grup_No;
                        if (user.Sirket_No == null)
                            user.Sirket_No = 1;
                        if (user.Departman_No == null)
                            user.Departman_No = 1;
                        _userDal.Update(user);
                        result = true;
                    }
                }
            }
            return result;
        }


        public List<int> GetUserOnlyUserID()
        {
            return _userDal.GetListOnlyUserID();
        }

        public int CountByGroupNumber(int GrupNo)
        {
            return _userDal.CountByGroupNumber(GrupNo);
        }


    }
}
