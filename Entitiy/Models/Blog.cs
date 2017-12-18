using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entitiy.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string Baslik { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public List<Yorum> Yorumlar { get; set; }

        public Blog()
        {
            EklenmeTarihi = DateTime.Now;
            GoruntulenmeSayisi = 0;
        }
    }
}
