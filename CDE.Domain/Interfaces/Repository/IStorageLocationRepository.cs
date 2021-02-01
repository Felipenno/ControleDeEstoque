using CDE.Domain.Entities;
using CDE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IStorageLocationRepository
    {
        Task<int> AddAsync(StorageLocation storageLocation);
        Task<int> UpdateAsync(StorageLocation storageLocation);
        Task<int> RemoveAsync(int id);
        Task<StorageLocation> GetByIdAsync(int id);

        Task<List<StorageLocationViewModel>> GetAllAsync();
    }
}
