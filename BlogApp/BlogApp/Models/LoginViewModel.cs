
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage="Parola boş bırakılamaz.")]
        [StringLength(10,ErrorMessage ="{0} alanı en az {2} karakter maksimum {1} karakter uzunluğunda olmalıdır." ,MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }



    }
}