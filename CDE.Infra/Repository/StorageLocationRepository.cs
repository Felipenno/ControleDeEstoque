using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using CDE.Domain.ViewModels;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CDE.Infra.Repository
{
    public class StorageLocationRepository : IStorageLocationRepository
    {
        private readonly DataProviders _dataProviders;

        public StorageLocationRepository(DataProviders dataProviders)
        {
            _dataProviders = dataProviders;
        }

        public async Task<int> AddAsync(StorageLocation storageLocation)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    @"
                        insert into 
                            tb_storage_location(storage_location_Floor, storage_location_hall, storage_location_shelf, storage_location_bay, fk_product_id)
                        values
                            (@Floor, @Hall, @Shelf,  @Bay, @IdProduct);

                    ",
                    storageLocation
                 );

            }
        }

        public async Task<List<StorageLocationViewModel>> GetAllAsync()
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                var results = await connection.QueryAsync<StorageLocationViewModel, ProductModel, StorageLocationViewModel>
                (
                    @"
                        select
                            storage_location_id as StorageLocationId,
	                        storage_location_Floor as Floor,
	                        storage_location_hall as Hall,
	                        storage_location_shelf as Shelf,
	                        storage_location_bay as Bay,
	                        fk_product_id as IdProduct,
	                        product_id as ProductId,
	                        product_name as ProdutctName,
	                        product_quantity as ProductQuantity,
	                        product_active as ProductActive,
	                        product_group as ProductGroup,
	                        product_unit_of_measuremen as ProductUnitOfMeasurement
                        from tb_storage_location as st left join tb_product as p on (st.fk_product_id = p.product_id);
                    "
                    ,
                    map: (storageLocation, product) =>
                    {
                        storageLocation.Product = product;
                        return storageLocation;
                    },
                    splitOn: "StorageLocationId, ProductId"
                );

                return results.AsList();
            }
        }

        public async Task<StorageLocation> GetByIdAsync(int id)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<StorageLocation>
                (
                    $@"
                        select
                            storage_location_id as StorageLocationId,
	                        storage_location_Floor as Floor,
	                        storage_location_hall as Hall,
	                        storage_location_shelf as Shelf,
	                        storage_location_bay as Bay,
	                        fk_product_id as IdProduct
                        from tb_storage_location  where storage_location_id = {id};
                    "
                );
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    $@"
                        delete from tb_storage_location where storage_location_id = {id}; 
                    "
                );
            }
        }

        public async Task<int> UpdateAsync(StorageLocation storageLocation)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    $@"
                        update 
                            tb_storage_location 
                        set 
                            storage_location_Floor = @Floor, storage_location_hall = @Hall, storage_location_shelf = @Shelf, storage_location_bay = @Bay, fk_product_id = @IdProduct 
                        where 
                            storage_location_id = @StorageLocationId;
                            
                    ",
                    storageLocation
                );
            }
        }
    }
}
