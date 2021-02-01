using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using CDE.Domain.ViewModels;
using Dapper;
using Slapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CDE.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataProviders _dataProviders;

        public ProductRepository(DataProviders dataProviders)
        {
            _dataProviders = dataProviders;
        }

        public async Task<int> AddAsync(Product product)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    @"
                        insert into
	                        tb_product(product_name, product_quantity, product_active, product_group, product_unit_of_measuremen)
                        values(@ProdutctName, @ProductQuantity, @ProductActive,  @ProductGroup, @ProductUnitOfMeasurement);

                    ",
                    product
                 );
            }
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                var results = await connection.QueryAsync<dynamic>
                (
                    @"
                        SELECT
                            product_id as ProductId,
                            product_name as ProdutctName,
                            product_quantity as ProductQuantity,
                            product_active as ProductActive,
                            product_group as ProductGroup,
                            product_unit_of_measuremen as ProductUnitOfMeasurement,
                            storage_location_id as StorageLocations_StorageLocationId, 
                            storage_location_Floor as StorageLocations_Floor, 
                            storage_location_hall as StorageLocations_Hall, 
                            storage_location_shelf as StorageLocations_Shelf, 
                            storage_location_bay as StorageLocations_Bay
                        FROM tb_product as p 
                        LEFT JOIN tb_storage_location as st on (p.product_id = st.storage_location_id)
                        ORDER BY p.product_id;

                    "
                );

                AutoMapper.Configuration.AddIdentifier(
                    typeof(ProductViewModel), "ProductId");

                AutoMapper.Configuration.AddIdentifier(
                    typeof(StorageLocationModel), "StorageLocationId");

                List<ProductViewModel> products = AutoMapper.MapDynamic<ProductViewModel>(results).ToList();

                return products;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Product>
                (
                    $@"
                        SELECT
                            product_id as ProductId,
                            product_name as ProdutctName,
                            product_quantity as ProductQuantity,
                            product_active as ProductActive,
                            product_group as ProductGroup,
                            product_unit_of_measuremen as ProductUnitOfMeasurement
                        FROM tb_product where product_id = {id};
                    "
                );
            }
        }

        public async Task<List<Product>> SearchByName(string productName)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                var results = await connection.QueryAsync<Product>
                (
                    $@"
                        SELECT
                            product_id as ProductId,
                            product_name as ProdutctName,
                            product_quantity as ProductQuantity,
                            product_active as ProductActive,
                            product_group as ProductGroup,
                            product_unit_of_measuremen as ProductUnitOfMeasurement
                        FROM tb_product where product_name like ('%{productName}%');

                    "
                );

                return results.AsList();
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    $@"
                        delete from tb_product where product_id = {id}; 
                    "
                );
            }
        }

        public async Task<int> UpdateAsync(Product product)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    $@"
                        update 
                            tb_product 
                        set 
                            product_name = @ProdutctName, product_quantity = @ProductQuantity, product_active = @ProductActive, product_group = @ProductGroup, product_unit_of_measuremen = @ProductUnitOfMeasurement 
                        where 
                            product_id = @ProductId;                            
                    ",
                    product
                );
            }
        }
    }
}
