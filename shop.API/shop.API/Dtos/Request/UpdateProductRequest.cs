using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Dtos.Request
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string ImageUrl { get; set; }
        public int? Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
