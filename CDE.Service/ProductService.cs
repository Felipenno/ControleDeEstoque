using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(ProductCreateViewModel productViewModel)
        {
            Product product = _mapper.Map<ProductCreateViewModel, Product>(productViewModel);
            int affectedRows = await _productRepository.AddAsync(product);
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<List<ProductViewModel>> SearchByName(string productName)
        {
            var product = await _productRepository.SearchByName(productName);
            return _mapper.Map<List<Product>, List<ProductViewModel>>(product);
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<Product, ProductViewModel>(product);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var affectedRows = await _productRepository.RemoveAsync(id);
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(ProductUpdateViewModel productViewlModel)
        {
            Product product = _mapper.Map<ProductUpdateViewModel, Product>(productViewlModel);
            var affectedRows = await _productRepository.UpdateAsync(product);
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }
    }
}
