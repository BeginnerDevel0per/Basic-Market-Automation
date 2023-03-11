using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_OTOMASYON_SQL.model
{
    public class baklagilgetir
    {
        public int id { get; set; }
        public string urunturu { get; set; }
        public string barkodkod { get; set; }
        public DateTime olusturmatarih { get; set; }

        public string urunisim { get; set; }

        public int kilo { get; set; }

        public int fiyat { get; set; }
    }
}
