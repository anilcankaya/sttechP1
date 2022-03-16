using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Models
{
    public class Product
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olabilir")]
        [MinLength(3, ErrorMessage = "En az üç harf olmalıdır")]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage ="Fiyat alanı boş olamaz")]
        public double? Price { get; set; }
        public double? Discount { get; set; } = 0;
        public string ImageUrl { get; set; }
        public int? Stock { get; set; }
        //[ForeignKey("Category")]
        [Display(Name="Kategorisi")]
        public int CategoryId { get; set; }

        //navigation property
        public Category Category { get; set; }





    }
}
