using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using efcoreApp.Data;

namespace efcoreApp.Models
{
    public class KursViewModel
    {
        public int KursId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Kurs Başlığı")]
        public string? Baslik { get; set; }

        [DisplayName("Öğretmen Id")]
        public int OgretmenId { get; set; }
        public ICollection<KursKayit> Ogrenciler { get; set; } = new List<KursKayit>();
        
    }
}