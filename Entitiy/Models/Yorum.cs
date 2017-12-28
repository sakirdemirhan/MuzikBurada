using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitiy.Models
{
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        public string YorumIcerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        [ForeignKey("KullaniciYorum")]
        public string YorumYapanId { get; set; }
        public virtual Kullanici KullaniciYorum { get; set; }
        [ForeignKey("BlogYorum")]
        public int BlogYorumID { get; set; }
        public virtual Blog BlogYorum { get; set; }
        public Yorum()
        {
            EklenmeTarihi = DateTime.Now;
        }
    }
}
