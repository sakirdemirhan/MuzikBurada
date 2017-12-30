using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entitiy.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [Required(ErrorMessage = "Zorunlu alan!")]
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        [Required(ErrorMessage = "Zorunlu alan!")]
        [MaxLength(100)]
        public string Etiket { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        
        public Blog()
        {
            EklenmeTarihi = DateTime.Now;
            GoruntulenmeSayisi = 0;
        }
    }
}
