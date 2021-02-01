using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Service
{
    public class StorageLocationService : IStorageLocationService
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        private readonly IMapper _mapper;

        public StorageLocationService(IStorageLocationRepository storageLocationRepository, IMapper mapper)
        {
            _storageLocationRepository = storageLocationRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(StorageLocationCreateViewModel storageLocationViewModel)
        {
            StorageLocation storageLocation = _mapper.Map<StorageLocationCreateViewModel, StorageLocation>(storageLocationViewModel);
            int affectedRows = await _storageLocationRepository.AddAsync(storageLocation);
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<StorageLocationViewModel>> GetAllAsync()
        {
            return await _storageLocationRepository.GetAllAsync();
        }

        public async Task<StorageLocationViewModel> GetByIdAsync(int id)
        {
            var storageLocation = await _storageLocationRepository.GetByIdAsync(id);
            return _mapper.Map<StorageLocation, StorageLocationViewModel>(storageLocation);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var affectedRows = await _storageLocationRepository.RemoveAsync(id);
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(StorageLocationUpdateViewModel storageLocationViewModel)
        {
            var storageLocation = _mapper.Map<StorageLocationUpdateViewModel, StorageLocation>(storageLocationViewModel);
            var affectedRows = await _storageLocationRepository.UpdateAsync(storageLocation);
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }
    }
}
