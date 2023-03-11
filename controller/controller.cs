using MARKET_OTOMASYON_SQL.dao;
using MARKET_OTOMASYON_SQL.enumaration;
using MARKET_OTOMASYON_SQL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_OTOMASYON_SQL.controller
{         // classlar arası haberleşmeyi sağlıyor veri aktarımı
    //kontrol ettirme katmanı adı üstünde
    public class Controller
    {
        repository repository;

        public Controller()
        {
            repository = new repository();
        }
        public user login(string kullaniciadi, string sifre)
        {
            user result;
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                result = repository.login(kullaniciadi, sifre);
                return result;

            }
            else
            {
                user user = new user();
                user.status = loginstatus.eksikparametre;
                return user;
            }

        }
        public List<urunarama> GetUrunaramas(urunarama urunarama)
        {
            List<urunarama> result = repository.GetUrunaramas(urunarama);
            return result;
         
        }
        public List<logintable> getlogintable()
        {
            List<logintable> logintable = repository.getlogintable();
            return logintable;
        }

        public List<tumurunler> gettumurunler()
        {
            List<tumurunler> tumurunlers = repository.gettumurunler();
            return tumurunlers;
        }

        public List<baklagilgetir> GetBaklagilgetirs()
        {
            List<baklagilgetir> baklagilgetirs = repository.GetBaklagilgetirs();
            return baklagilgetirs;
        }
        public List<meyvegetir> GetMeyvegetirs()
        {
            List<meyvegetir> meyvegetirs = repository.GetMeyvegetirs();
            return meyvegetirs;
        }
        public List<sebzegetir> GetSebzegetirs()
        {
            List<sebzegetir> sebzegetirs = repository.GetSebzegetirs();
            return sebzegetirs;
        }
        public List<etsutgetir> GetEtsutgetirs()
        {
            List<etsutgetir> etsutgetirs = repository.GetEtsutgetirs();
            return etsutgetirs;
        }
        public loginstatus urunekle(tumurunler tumurunler)
        {
            if (!string.IsNullOrEmpty(tumurunler.urunturu) && !string.IsNullOrEmpty(tumurunler.urunisim) && !string.IsNullOrEmpty(tumurunler.fiyat.ToString()) && !string.IsNullOrEmpty(tumurunler.barkodkod) && !string.IsNullOrEmpty(tumurunler.kilo.ToString()))
            {
                loginstatus result = repository.urunekle(tumurunler);
                return result;

            }
            else
            {
                return loginstatus.eksikparametre;
            }
        }
        public loginstatus kullaniciekle(user user)
        {
            if(!string.IsNullOrEmpty(user.emailadres) & !string.IsNullOrEmpty(user.kullaniciadi)& !string.IsNullOrEmpty(user.guvenlikcevap) & !string.IsNullOrEmpty(user.guvenliksoru)
                & !string.IsNullOrEmpty(user.yetki))
            {
                loginstatus result = repository.kullaniciekle(user);
                return result;
            }
            else
            {
                return loginstatus.eksikparametre;
            }
        }
        public loginstatus kullanicisil(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return repository.kullanicisil(id);
            }
            else
            {
                return loginstatus.eksikparametre;
            }

        }
        public loginstatus kullaniciguncelle(user user)
        {

            if (!string.IsNullOrEmpty(user.emailadres) && !string.IsNullOrEmpty(user.kullaniciadi) && !string.IsNullOrEmpty(user.guvenlikcevap) && !string.IsNullOrEmpty(user.guvenliksoru)
               && !string.IsNullOrEmpty(user.yetki))
            {
                loginstatus result = repository.kullaniciguncelle(user);
                return result;
            }
            else
            {
                return loginstatus.eksikparametre;


            }
            }

        public loginstatus urunsil(int id)
        {
            
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return repository.urunsil(id);
            }
            else
            {
                return loginstatus.eksikparametre;
            }

        }
        public loginstatus doauthentication(string kullaniciadi, string guvenliksorusu, string guvenlikcevabı) //şifre değiştirme ekranı guvenlik sorusu kısmı methodu
        {
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(guvenliksorusu) && !string.IsNullOrEmpty(guvenlikcevabı))
            {
                loginstatus result = repository.doauthentication(kullaniciadi, guvenliksorusu, guvenlikcevabı);
                if (result == loginstatus.basarili)
                {
                    return result;
                }
                else
                {
                    return loginstatus.basarisiz;
                }

            }
            else
            {
                return loginstatus.eksikparametre;

            }
        }
        public loginstatus maildogrulama(string kullaniciadi, string mail)
        {
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(mail))
            {
                loginstatus result = repository.maildogrulama(kullaniciadi, mail);
                if (result == loginstatus.basarili)
                {
                    return result;
                }
                else
                {
                    return loginstatus.basarisiz;
                }

            }
            else
            {
                return loginstatus.eksikparametre;
            }


        }
        public loginstatus sifredegistirme(string kullaniciadi, string sifre)

        {
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                return repository.sifredegistime(kullaniciadi, sifre);

            }
            else
            {
                return loginstatus.eksikparametre;
            }
        }
        public string kontrolemailadres(string kullaniciadi)
        {
            return repository.kontrolemailadres(kullaniciadi);

        }







    }
}
