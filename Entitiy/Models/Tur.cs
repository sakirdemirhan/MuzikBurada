using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.Models
{
    public class Tur
    {
        [Key]
        public int TurID { get; set; }
        [Required(ErrorMessage = "Zorunlu alan!")]
        public string TurAdi { get; set; }
        public string TurAciklama { get; set; }

    }
}
