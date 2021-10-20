using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Description, t => t.Ignore());
            CreateMap<ProductDto, Product>()
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d=>d.UpdatedDate,t=>t.Ignore());
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
