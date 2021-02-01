using CDE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Service
{
    public interface IStorageLocationService
    {
        Task<bool> AddAsync(StorageLocationCreateViewModel storageLocationViewModel);
        Task<bool> UpdateAsync(StorageLocationUpdateViewModel storageLocationViewModel);
        Task<bool> RemoveAsync(int id);
        Task<StorageLocationViewModel> GetByIdAsync(int id);

        Task<List<StorageLocationViewModel>> GetAllAsync();
    }
}
