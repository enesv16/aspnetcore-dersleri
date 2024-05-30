
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılamaz.")]
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} karakter maksimum {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılamaz.")]
        [Compare(nameof(Password), ErrorMessage ="Parolalar eşleşmiyor.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrar")]
        public string? ConfirmPassword { get; set; }

    }
}