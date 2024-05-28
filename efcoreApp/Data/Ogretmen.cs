using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace efcoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? OgretmenAdSoyad
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }
        public string? Eposta { get; set; }

        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();

    }

}