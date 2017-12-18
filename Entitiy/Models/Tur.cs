using System.ComponentModel.DataAnnotations;
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
