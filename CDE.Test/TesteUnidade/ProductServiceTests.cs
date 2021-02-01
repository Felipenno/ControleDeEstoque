using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using CDE.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using CDE.Domain.Enum;
using CDE.Service.AutoMapper;

namespace CDE.Test.TesteUnidade
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductCreateViewModel _productCreateViewModel;
        //private readonly ProductUpdateViewModel _productUpdateViewModel;
        //private readonly ProductViewModel _productViewModel;
        private readonly Product _product;
        private int _affectedRows;

        public ProductServiceTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockMapper = new Mock<IMapper>();

            _product = new Product("arroz", 50, true, ProductGroup.Alimentos, UnitOfMeasurement.Kilo);
            _productCreateViewModel = new ProductCreateViewModel("arroz", 50, true, ProductGroup.Alimentos, UnitOfMeasurement.Kilo);

            _mockProductRepository.Setup(m => m.AddAsync(_product)).ReturnsAsync(_affectedRows);
            _mockMapper.Setup(m => m.Map<Product>(_productCreateViewModel)).Returns(_product);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public async void Product_AddAsync(int affectedRows)
        {
            _affectedRows = affectedRows;

            var productService = new ProductService(_mockProductRepository.Object, _mockMapper.Object);
            var isSucess = await productService.AddAsync(_productCreateViewModel);

            _mockProductRepository.Verify(p => p.AddAsync(_product), Times.Once());
            _mockMapper.Verify(m => m.Map<Product>(_productCreateViewModel), Times.Once());

            if (affectedRows > 0)
            {
                isSucess.Should().BeTrue();
            }
            else
            {
                isSucess.Should().BeFalse();
            }
            
        }

        //[Fact]
        //public void Product_GetAllAsync()
        //{
        //    return await _productRepository.GetAllAsync();
        //}

        //[Fact]
        //public void Product_SearchByName()
        //{
        //    var product = await _productRepository.SearchByName(productName);
        //    return _mapper.Map<List<Product>, List<ProductViewModel>>(product);
        //}

        //[Fact]
        //public void Product_GetByIdAsync()
        //{
        //    Product product = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<Product, ProductViewModel>(product);
        //}

        //[Fact]
        //public void Product_RemoveAsync()
        //{
        //    var affectedRows = await _productRepository.RemoveAsync(id);
        //    if (affectedRows > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //[Fact]
        //public void Product_UpdateAsync()
        //{
        //    Product product = _mapper.Map<ProductUpdateViewModel, Product>(productViewlModel);
        //    var affectedRows = await _productRepository.UpdateAsync(product);
        //    if (affectedRows > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

    }
}
