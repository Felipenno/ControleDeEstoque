using CDE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Service
{
    public interface IProductService
    {
        Task<bool> AddAsync(ProductCreateViewModel productViewModel);
        Task<bool> UpdateAsync(ProductUpdateViewModel productViewlModel);
        Task<bool> RemoveAsync(int id);
        Task<ProductViewModel> GetByIdAsync(int id);

        Task<List<ProductViewModel>> GetAllAsync();
        Task<List<ProductViewModel>> SearchByName(string productName);
    }
}
