using System;
using System.ComponentModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitiy.Models
{
    public class Kullanici : IdentityUser
    {
        [Required(ErrorMessage = "Required Field !")]
        [MaxLength(100)]
        [DisplayName("Group Name")]
        public string GrupAdi { get; set; }
        [Required(ErrorMessage = "Required Field !")]
        [DisplayName("Description")]
        public string Aciklama { get; set; }
        public string WebSite { get; set; }
        [DisplayName("Image")]
        public string Resim { get; set; }
        [DisplayName("YouTube Link")]
        public string YoutubeLinki { get; set; }
        [DisplayName("Group Members")]
        public string GrupUyeleri { get; set; }
        public int Begeni { get; set; }
        [ForeignKey("KullaniciTur")]
        public int? TurID { get; set; }
        [DisplayName("Start Date")]
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
