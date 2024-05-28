using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name ="Ürün No") ]
        public int ProductId { get; set; }

        public string? SecretKey { get; set; }

        [Required(ErrorMessage ="Ürün ismini girmek zorunludur.")]
        [Display(Name ="Ürün Adı") ]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Ürün fiyatını girmek zorunludur.")]
        [Display(Name ="Fiyat") ]
        [Range(0,100000,ErrorMessage ="Ürün fiyat aralığı 0 ile 1000 arasında olmalıdır.")]
        public decimal? Price { get; set; }


        [Display(Name ="Ürün Resmi") ]
        public string Image { get; set; } = string.Empty;

        [Display(Name ="Ürün Aktifliği") ]
        public bool IsActive { get; set; }
        [Display(Name ="Ürün Kategorisi") ]
        [Required]
        public int? CategoryId { get; set; }
    }
}