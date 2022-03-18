using AutoMapper;
using shop.API.Dtos.Request;
using shop.API.Dtos.Response;
using shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductRequest, Product>();
            CreateMap<Product, ProductListResponse>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
