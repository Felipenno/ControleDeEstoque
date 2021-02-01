using CDE.Domain.Entities;
using CDE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> RemoveAsync(int id);
        Task<Product> GetByIdAsync(int id);

        Task<List<ProductViewModel>> GetAllAsync();
        Task<List<Product>> SearchByName(string productName);
    }
}
