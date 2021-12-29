using AutoMapper;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketManagement.MapperClasses
{
    public class categoryProfileMapper : Profile
    {
        public categoryProfileMapper()
        {
            CreateMap<UpdateCategory, Category>();
            CreateMap<Category, UpdateCategory>();

            CreateMap<UpdateProduct, Product>();
            CreateMap<Product, UpdateProduct>();
               
        }
       
    }
}
