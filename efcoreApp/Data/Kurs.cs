using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        
        [DisplayName("Başlık")]
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!;

        public ICollection<KursKayit> Ogrenciler { get; set; } = new List<KursKayit>();
    }
}