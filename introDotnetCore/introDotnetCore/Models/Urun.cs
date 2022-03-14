using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace introDotnetCore.Models
{
    public class Urun
    {
        [Required(ErrorMessage ="Ad dolu olmalı")]
        [MaxLength(50)]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Fiyat dolu olmalı")]
        [DataType(DataType.Currency)]
        public double? Fiyat { get; set; }
        [Required(ErrorMessage = "Açıklama dolu olmalı")]
        public string Aciklama { get; set; }
    }
}
