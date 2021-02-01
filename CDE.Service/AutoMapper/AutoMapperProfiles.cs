using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.ViewModels;

namespace CDE.Service.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductCreateViewModel, Product>()
                .ConstructUsing(src => new Product(src.ProdutctName, src.ProductQuantity, src.ProductActive, src.ProductGroup, src.ProductUnitOfMeasurement));

            CreateMap<ProductUpdateViewModel, Product>()
                .ConstructUsing(src => new Product(src.ProductId ,src.ProdutctName, src.ProductQuantity, src.ProductActive, src.ProductGroup, src.ProductUnitOfMeasurement));

            CreateMap<Product, ProductViewModel>();

            CreateMap<StorageLocationCreateViewModel, StorageLocation>()
                .ConstructUsing(src => new StorageLocation(src.Floor, src.Hall, src.Shelf, src.Bay, src.IdProduct));

            CreateMap<StorageLocationUpdateViewModel, StorageLocation>()
                .ConstructUsing(src => new StorageLocation(src.StorageLocationId, src.Floor, src.Hall, src.Shelf, src.Bay, src.IdProduct ));

            CreateMap<StorageLocation, StorageLocationViewModel>();

            CreateMap<User, UserLoginViewModel>();

            CreateMap<UserRegisterViewModel, User>()
                .ConstructUsing(src => new User(src.UserName, src.UserEmail, src.UserPassword));

            CreateMap<User, UserJwtModel>();
        }
    }
}
