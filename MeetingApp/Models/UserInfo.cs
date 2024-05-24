
using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad alanı zorunlu") ]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Telefon Alanı zorunlu")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="Email alanı zorunlu")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email giriniz!")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Lütfen birini seçiniz.")]
        public bool WillAttend { get; set; }
    }
}