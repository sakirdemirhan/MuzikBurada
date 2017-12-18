using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitiy.Models
{
    public class Kullanici:IdentityUser
    {
        [Required(ErrorMessage = "Zorunlu alan!")]
        [MaxLength(100)]
        public string GrupAdi { get; set; }
        [Required(ErrorMessage = "Zorunlu alan!")]
        public string Aciklama { get; set; }
        public string WebSite { get; set; }
        public string Resim { get; set; }
        public string YoutubeLinki { get; set; }
        public string GrupUyeleri { get; set; }
        public int Begeni { get; set; }
        [ForeignKey("KullaniciTur")]
        public int? TurID { get; set; }
        public DateTime? KurulusTarihi { get; set; }
        public DateTime SiteKayitTarihi { get; set; }
        public virtual Tur KullaniciTur { get; set; }
        public Kullanici()
        {
            SiteKayitTarihi = DateTime.Now;
            Begeni = 0;
        }

    }
}
