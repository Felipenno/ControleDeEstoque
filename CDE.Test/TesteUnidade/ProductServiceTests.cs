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
using AutoFixture;
using System.Threading.Tasks;
using System.Linq;

namespace CDE.Test.TesteUnidade
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private Mock<IMapper> _mockIMapper;
        private IProductService _productService;

        private readonly Fixture _fixture;

        public ProductServiceTests()
        {
            _mockIMapper = new Mock<IMapper>();
            _mockProductRepository = new Mock<IProductRepository>();
            _fixture = new Fixture();
            _productService = new ProductService(_mockProductRepository.Object, _mockIMapper.Object);
        }

        [Fact]
        public async Task Product_AddAsync()
        {
            var product = _fixture.Create<Product>();
            var productModel = _fixture.Create<ProductCreateViewModel>();
            _mockIMapper.Setup(m => m.Map<ProductCreateViewModel, Product>(productModel)).Returns(product);
            _mockProductRepository.Setup(m => m.AddAsync(product)).ReturnsAsync(1);

            var actionSuccess = await _productService.AddAsync(productModel);

            //_mockIMapper.Verify(a => a.Map<ProductCreateViewModel, Product>(productModel), Times.Once);
            actionSuccess.Should().Be(true);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Product_GetAllAsync()
        {
            var listProductModel = _fixture.CreateMany<ProductViewModel>();
            _mockProductRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(listProductModel.ToList());

            var productModel = await _productService.GetAllAsync();

            productModel.Should().BeOfType<List<ProductViewModel>>();
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Product_SearchByName()
        {
            string searchTerm = "nome prduto";
            var listProduct = _fixture.CreateMany<Product>().ToList();
            var listProductModel = _fixture.CreateMany<ProductViewModel>().ToList();
            _mockProductRepository.Setup(m => m.SearchByName(searchTerm)).ReturnsAsync(listProduct);
            _mockIMapper.Setup(m => m.Map<List<Product>, List<ProductViewModel>>(listProduct)).Returns(listProductModel);

            var productReceived = await _productService.SearchByName(searchTerm);

            productReceived.Should().BeEquivalentTo(listProductModel);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Product_GetByIdAsync()
        {
            var product = _fixture.Create<Product>();
            var productModel = _fixture.Create<ProductViewModel>();
            _mockProductRepository.Setup(m => m.GetByIdAsync(product.ProductId)).ReturnsAsync(product);
            _mockIMapper.Setup(m => m.Map<Product, ProductViewModel>(product)).Returns(productModel);

            var productReceived = await _productService.GetByIdAsync(product.ProductId);

            productReceived.Should().Be(productModel);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Product_RemoveAsync()
        {
            var product = _fixture.Create<Product>();
            _mockProductRepository.Setup(m => m.RemoveAsync(product.ProductId)).ReturnsAsync(1);

            var actionSuccess = await _productService.RemoveAsync(product.ProductId);

            actionSuccess.Should().Be(true);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Product_UpdateAsync()
        {
            var productModel = _fixture.Create<ProductUpdateViewModel>();
            var product = _fixture.Create<Product>();
            _mockProductRepository.Setup(m => m.UpdateAsync(product)).ReturnsAsync(1);
            _mockIMapper.Setup(m => m.Map<ProductUpdateViewModel, Product>(productModel)).Returns(product);

            var actionSuccess = await _productService.UpdateAsync(productModel);

            actionSuccess.Should().Be(true);
            Mock.VerifyAll();
        }

    }
}
