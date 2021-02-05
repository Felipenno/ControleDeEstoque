using AutoFixture;
using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using CDE.Service;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CDE.Test.TesteUnidade
{
    public class StorageLocationServiceTests
    {
        private readonly Mock<IStorageLocationRepository> _mockStorageLocationRepository;
        private readonly Mock<IMapper> _mockIMapper;
        private readonly IStorageLocationService _storageLocationService;

        private readonly Fixture _fixture;

        public StorageLocationServiceTests()
        {
            _mockIMapper = new Mock<IMapper>();
            _mockStorageLocationRepository = new Mock<IStorageLocationRepository>();
            _fixture = new Fixture();
            _storageLocationService = new StorageLocationService(_mockStorageLocationRepository.Object, _mockIMapper.Object);
        }

        [Fact]
        public async Task StorageLocation_AddAsync()
        {
            var storageLocation = _fixture.Create<StorageLocation>();
            var storageLocationCreateModel = _fixture.Create<StorageLocationCreateViewModel>();
            _mockIMapper.Setup(m => m.Map<StorageLocationCreateViewModel, StorageLocation>(storageLocationCreateModel)).Returns(storageLocation);
            _mockStorageLocationRepository.Setup(m => m.AddAsync(storageLocation)).ReturnsAsync(1);

            var actionSuccess = await _storageLocationService.AddAsync(storageLocationCreateModel);

            actionSuccess.Should().Be(true);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task StorageLocation_GetAllAsync()
        {
            var listStorageLocationtModel = _fixture.CreateMany<StorageLocationViewModel>();
            _mockStorageLocationRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(listStorageLocationtModel.ToList());

            var StorageLocationtModel = await _storageLocationService.GetAllAsync();

            StorageLocationtModel.Should().BeOfType<List<StorageLocationViewModel>>();
            Mock.VerifyAll();
        }

        [Fact]
        public async Task StorageLocation_GetByIdAsync()
        {
            var storageLocation = _fixture.Create<StorageLocation>();
            var storageLocationViewModel= _fixture.Create<StorageLocationViewModel>();
            _mockStorageLocationRepository.Setup(m => m.GetByIdAsync(storageLocation.StorageLocationId)).ReturnsAsync(storageLocation);
            _mockIMapper.Setup(m => m.Map<StorageLocation, StorageLocationViewModel>(storageLocation)).Returns(storageLocationViewModel);

            var storageLocationReceived = await _storageLocationService.GetByIdAsync(storageLocation.StorageLocationId);

            storageLocationReceived.Should().Be(storageLocationViewModel);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task StorageLocation_RemoveAsync()
        {
            var storageLocation = _fixture.Create<StorageLocation>();
            _mockStorageLocationRepository.Setup(m => m.RemoveAsync(storageLocation.StorageLocationId)).ReturnsAsync(1);

            var actionSuccess = await _storageLocationService.RemoveAsync(storageLocation.StorageLocationId);

            actionSuccess.Should().Be(true);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task StorageLocation_UpdateAsync()
        {
            var storageLocationViewModel = _fixture.Create<StorageLocationUpdateViewModel>();
            var storageLocation = _fixture.Create<StorageLocation>();
            _mockStorageLocationRepository.Setup(m => m.UpdateAsync(storageLocation)).ReturnsAsync(1);
            _mockIMapper.Setup(m => m.Map<StorageLocationUpdateViewModel, StorageLocation>(storageLocationViewModel)).Returns(storageLocation);

            var actionSuccess = await _storageLocationService.UpdateAsync(storageLocationViewModel);

            actionSuccess.Should().Be(true);
            Mock.VerifyAll();
        }
    }
}
