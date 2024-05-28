using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public ICollection<KursKayit> Ogrenciler { get; set; } = new List<KursKayit>();
    }
}