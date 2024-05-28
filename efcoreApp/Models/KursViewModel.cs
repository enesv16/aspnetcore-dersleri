using efcoreApp.Data;

namespace efcoreApp.Models
{
    public class KursViewModel
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }
        public int? OgretmenId { get; set; }
        public ICollection<KursKayit> Ogrenciler { get; set; } = new List<KursKayit>();
        
    }
}