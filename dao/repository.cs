using MARKET_OTOMASYON_SQL.enumaration;
using MARKET_OTOMASYON_SQL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_OTOMASYON_SQL.dao
{
    public class repository
    {
        //veritabanıyla iletişime geçen class

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        int returnvalue;
        List<logintable> logintables;
        List<tumurunler> tumurunlers;
        List<baklagilgetir> baklagilgetirs;
        List<meyvegetir> meyvegetirs;
        List<sebzegetir> sebzegetirs;
        List<etsutgetir> etsutgetirs;
        List<urunarama> urunaramas;
        
        public repository()
        {
            con = new SqlConnection("Data Source=ASUS;Initial Catalog=marketotomasyon;Integrated Security=True");
        }
        public void baglantiayarla()
        {
            if (con.State == System.Data.ConnectionState.Closed) // eğer con bağlantım kapalıysa sen bunu aç
            {
                con.Open();
            }
            else //eğer acıksada sen bunu kapat
            {
                con.Close();
            }
        }
        public user login(string kullaniciadi, string sifre)
        { //enum kullanıldı loginstatus enumdır
            con.Open();
            cmd = new SqlCommand("select * from logintable where kullaniciadi=@kulad and sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciadi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                user user = new user();
                user.id = Convert.ToInt32(dr["id"].ToString());
                user.kullaniciadi = dr["kullaniciadi"].ToString();
                user.sifre = dr["sifre"].ToString();
                user.yetki = dr["yetki"].ToString();
                user.emailadres = dr["emailadres"].ToString();
                user.guvenliksoru = dr["guvenliksorusu"].ToString();
                user.guvenlikcevap = dr["guvenlikcevabı"].ToString();
                user.status = loginstatus.basarili;
                return user;
            }
            else
            {
                user user = new user();
                user.status = loginstatus.basarisiz;
                return user;

            }
        }
        public List<logintable> getlogintable()
        {
            logintables = new List<logintable>();
            con.Open();
            cmd = new SqlCommand("guvenliksorusugetir_sp", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                logintable logintable = new logintable();
                logintable.id = Convert.ToInt32(dr["id"].ToString());
                logintable.kullaniciadi = dr["kullaniciadi"].ToString();
                logintable.sifre = dr["sifre"].ToString();
                logintable.yetki = dr["yetki"].ToString();
                logintable.emailadres = dr["emailadres"].ToString();
                logintable.guvenliksoru = dr["guvenliksorusu"].ToString();
                logintable.guvenlikcevap = dr["guvenlikcevabı"].ToString();
                logintables.Add(logintable);
            }
            con.Close();
            return logintables;
        }

        public List<tumurunler> gettumurunler()
        {
            tumurunlers = new List<tumurunler>();
            con.Open();
            cmd = new SqlCommand("select * from tumurunlertable", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tumurunler tumurunler = new tumurunler();
                tumurunler.id = Convert.ToInt32(dr["id"].ToString());
                tumurunler.urunturu = dr["urunturu"].ToString();
                tumurunler.barkodkod = dr["barkodkod"].ToString();
                tumurunler.olusturmatarih = Convert.ToDateTime(dr["olusturmatarih"].ToString());
                tumurunler.urunisim = dr["urunisim"].ToString();
                tumurunler.kilo = Convert.ToInt32(dr["kilo"].ToString());
                tumurunler.fiyat = Convert.ToInt32(dr["fiyat"].ToString());
                tumurunlers.Add(tumurunler);
            }
            con.Close();
            return tumurunlers;
        }
        public List<baklagilgetir> GetBaklagilgetirs()
        {
            baklagilgetirs = new List<baklagilgetir>();
            con.Open();
            cmd = new SqlCommand("select * from tumurunlertable where urunturu='baklagil'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                baklagilgetir baklagilgetir = new baklagilgetir();
                baklagilgetir.id = Convert.ToInt32(dr["id"].ToString());
                baklagilgetir.urunturu = dr["urunturu"].ToString();
                baklagilgetir.barkodkod = dr["barkodkod"].ToString();
                baklagilgetir.olusturmatarih = Convert.ToDateTime(dr["olusturmatarih"].ToString());
                baklagilgetir.urunisim = dr["urunisim"].ToString();
                baklagilgetir.kilo = Convert.ToInt32(dr["kilo"].ToString());
                baklagilgetir.fiyat = Convert.ToInt32(dr["fiyat"].ToString());
                baklagilgetirs.Add(baklagilgetir);
            }
            con.Close();
            return baklagilgetirs;

        }
        public List<meyvegetir> GetMeyvegetirs()
        {
            meyvegetirs = new List<meyvegetir>();
            con.Open();
            cmd = new SqlCommand("select * from tumurunlertable where urunturu='meyve'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                meyvegetir meyvegetir = new meyvegetir();
                meyvegetir.id = Convert.ToInt32(dr["id"].ToString());
                meyvegetir.urunturu = dr["urunturu"].ToString();
                meyvegetir.barkodkod = dr["barkodkod"].ToString();
                meyvegetir.olusturmatarih = Convert.ToDateTime(dr["olusturmatarih"].ToString());
                meyvegetir.urunisim = dr["urunisim"].ToString();
                meyvegetir.kilo = Convert.ToInt32(dr["kilo"].ToString());
                meyvegetir.fiyat = Convert.ToInt32(dr["fiyat"].ToString());
                meyvegetirs.Add(meyvegetir);
            }
            con.Close();
            return meyvegetirs;

        }
        public List<sebzegetir> GetSebzegetirs()
        {
            sebzegetirs = new List<sebzegetir>();
            con.Open();
            cmd = new SqlCommand("select * from tumurunlertable where urunturu='sebze'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sebzegetir sebzegetir = new sebzegetir();
                sebzegetir.id = Convert.ToInt32(dr["id"].ToString());
                sebzegetir.urunturu = dr["urunturu"].ToString();
                sebzegetir.barkodkod = dr["barkodkod"].ToString();
                sebzegetir.olusturmatarih = Convert.ToDateTime(dr["olusturmatarih"].ToString());
                sebzegetir.urunisim = dr["urunisim"].ToString();
                sebzegetir.kilo = Convert.ToInt32(dr["kilo"].ToString());
                sebzegetir.fiyat = Convert.ToInt32(dr["fiyat"].ToString());
                sebzegetirs.Add(sebzegetir);
            }
            con.Close();
            return sebzegetirs;

        }
        public List<etsutgetir> GetEtsutgetirs()
        {
            etsutgetirs = new List<etsutgetir>();
            con.Open();
            cmd = new SqlCommand("select * from tumurunlertable where urunturu='et-süt'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                etsutgetir etsutgetir = new etsutgetir();
                etsutgetir.id = Convert.ToInt32(dr["id"].ToString());
                etsutgetir.urunturu = dr["urunturu"].ToString();
                etsutgetir.barkodkod = dr["barkodkod"].ToString();
                etsutgetir.olusturmatarih = Convert.ToDateTime(dr["olusturmatarih"].ToString());
                etsutgetir.urunisim = dr["urunisim"].ToString();
                etsutgetir.kilo = Convert.ToInt32(dr["kilo"].ToString());
                etsutgetir.fiyat = Convert.ToInt32(dr["fiyat"].ToString());
                etsutgetirs.Add(etsutgetir);
            }
            con.Close();
            return etsutgetirs;
        }

        public List<urunarama> GetUrunaramas(urunarama urunarama)
        {
            urunaramas = new List<urunarama>();
            con.Open();
            cmd = new SqlCommand("sp_urunarama", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@urunturu", urunarama.urunturu);
            cmd.Parameters.AddWithValue("@barkodkod", urunarama.barkodkod);
            cmd.Parameters.AddWithValue("@urunisim", urunarama.urunisim);
            cmd.Parameters.AddWithValue("@kilo", urunarama.kilo);
            cmd.Parameters.AddWithValue("@fiyat", urunarama.fiyat);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                urunarama = new urunarama();
                urunarama.id = Convert.ToInt32(dr["id"].ToString());
                urunarama.olusturmatarih = Convert.ToDateTime(dr["olusturmatarih"].ToString());
                urunarama.barkodkod = dr["barkodkod"].ToString();
                urunarama.urunisim = dr["urunisim"].ToString();
                urunarama.urunturu = dr["urunturu"].ToString();
                urunarama.kilo = Convert.ToInt32(dr["kilo"].ToString());
                urunarama.fiyat = Convert.ToInt32(dr["fiyat"].ToString());
                urunaramas.Add(urunarama);


            }
            con.Close();
            return urunaramas;




        }


        public loginstatus urunekle(tumurunler tumurunler)
        {
            con.Open();
            cmd = new SqlCommand("sp_urunekle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@urunturu", tumurunler.urunturu);
            cmd.Parameters.AddWithValue("@barkodkod", tumurunler.barkodkod);
            cmd.Parameters.AddWithValue("@urunisim", tumurunler.urunisim);
            cmd.Parameters.AddWithValue("@kilo", tumurunler.fiyat);
            cmd.Parameters.AddWithValue("@fiyat", tumurunler.fiyat);
            returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue == 1)
            {
                return loginstatus.basarili;

            }
            else
            {
                return loginstatus.basarisiz;
            }



        }
        public loginstatus kullaniciekle(user user)
        {
            con.Open();
            cmd = new SqlCommand("sp_kullaniciekle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciadi", user.kullaniciadi);
            cmd.Parameters.AddWithValue("@sifre", user.sifre);
            cmd.Parameters.AddWithValue("@emailadres", user.emailadres);
            cmd.Parameters.AddWithValue("@guvenliksorusu", user.guvenliksoru);
            cmd.Parameters.AddWithValue("@yetki", user.yetki);
            cmd.Parameters.AddWithValue("@guvenlikcevabı", user.guvenlikcevap);
            returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            {
                if (returnvalue == 1)
                {
                    return loginstatus.basarili;
                }
                else
                {
                    return loginstatus.basarisiz;
                }
            }
        }

        public loginstatus kullanicisil(int id)
        {
            con.Open();

            cmd = new SqlCommand("delete from loginTable where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue == 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }


        }

        public loginstatus kullaniciguncelle(user user)
        {
            con.Open();
            cmd = new SqlCommand("sp_kullaniciguncelle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@kullaniciadi", user.kullaniciadi);
            cmd.Parameters.AddWithValue("@sifre", user.sifre);
            cmd.Parameters.AddWithValue("@emailadres", user.emailadres);
            cmd.Parameters.AddWithValue("@guvenliksorusu", user.guvenliksoru);
            cmd.Parameters.AddWithValue("@yetki", user.yetki);
            cmd.Parameters.AddWithValue("@guvenlikcevabı", user.guvenlikcevap);

            returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue == 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }


        }

        public loginstatus urunsil(int id)
        {
            con.Open();
            cmd = new SqlCommand("delete  from tumurunlertable where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue == 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }




        }

        public loginstatus doauthentication(string kullaniciadi, string guvenliksorusu, string guvenlikcevabı) //şifre değiştirme ekranı guvenlik sorusu kısmı methodu
        {
            con.Open();
            cmd = new SqlCommand("select count(*) from logintable where kullaniciadi=@kulad and guvenliksorusu=@guvsoru and guvenlikcevabı=@guvcevap", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciadi);
            cmd.Parameters.AddWithValue("@guvsoru", guvenliksorusu);
            cmd.Parameters.AddWithValue("@guvcevap", guvenlikcevabı);
            returnvalue = (int)cmd.ExecuteScalar();
            con.Close();

            if (returnvalue == 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }

        }

        public loginstatus maildogrulama(string kullaniciadi, string mail)
        {
            con.Open();
            cmd = new SqlCommand("select count(*) from logintable where kullaniciadi=@kulad and emailadres=@emailadres", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciadi);
            cmd.Parameters.AddWithValue("@emailadres", mail);
            returnvalue = (int)cmd.ExecuteScalar();
            con.Close();
            if (returnvalue == 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }
        }

        public loginstatus sifredegistime(string kullaniciadi, string sifre)
        {
            con.Open();
            cmd = new SqlCommand("sifreguncelle_sp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            returnvalue = cmd.ExecuteNonQuery();


            con.Close();
            return loginstatus.basarili;

        }
        public string kontrolemailadres(string kullaniciadi)
        {
            con.Open();
            cmd = new SqlCommand("select emailadres from logintable where kullaniciadi=@kulad", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciadi);
            string emailadres = (string)cmd.ExecuteScalar();


            con.Close();

            return emailadres;
        }











    }
}
