using AutoMapper;
using Market.Api.Resources;
using Market.Core.Models;

namespace Market.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Product, ProductResource>();
            CreateMap<Category, CategoryResource>();

            // Resource to Domain
            CreateMap<ProductResource, Product>();
            CreateMap<CategoryResource, Category>();

            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
        }
    }
}