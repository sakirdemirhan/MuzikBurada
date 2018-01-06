using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class GrupModel
    {
        public string GrupAdi { get; set; }
        public string GrupAciklama { get; set; }
        public string GrupUyeleri { get; set; }
        public DateTime? KurulusTarihi { get; set; }
    }
}