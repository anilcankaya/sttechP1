using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Dtos.Response
{
    public class ProductListResponse
    {       
        public int Id { get; set; }           
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string ImageUrl { get; set; }        
        public int CategoryId { get; set; }
    }
}
