using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("Öğrenci Numarası")]
        public int OgrenciId { get; set; }
        [DisplayName("Ad")]
        public string? OgrenciAd { get; set; }
        [DisplayName("Soyad")]
        public string? OgrenciSoyad { get; set; }

        [DisplayName("Öğrenci Ad Soyadı")]
        public string? OgrenciAdSoyad
        {
            get
            {
                return OgrenciAd + " " + OgrenciSoyad;
            }
        }
        [EmailAddress]
        public string? Eposta { get; set; }
        public string? Phone { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}