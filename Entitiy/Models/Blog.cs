using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entitiy.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [Required(ErrorMessage = "Required Field !")]
        [Display(Name = "Title")]
        public string Baslik { get; set; }
        [Display(Name = "Content")]
        public string Icerik { get; set; }
        [Required(ErrorMessage = "Required Field !")]
        [MaxLength(100)]
        [Display(Name = "Tag")]
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
