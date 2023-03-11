using MARKET_OTOMASYON_SQL.enumaration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_OTOMASYON_SQL.model
{
    public class user
    {
        public int id { get; set; }
        public string kullaniciadi { get; set; }

        public string sifre { get; set; }
        public string emailadres { get; set; }
        public string guvenliksoru { get; set; }
        public string yetki { get; set; }
        public string guvenlikcevap { get; set; }

        public loginstatus status;
    }
}
