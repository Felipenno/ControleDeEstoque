using CDE.Domain.Enum;
using System.Collections.Generic;

namespace CDE.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProdutctName { get; private set; }
        public int ProductQuantity { get; private set; }
        public bool ProductActive { get; private set; }
        public ProductGroup ProductGroup { get; private set; }
        public UnitOfMeasurement ProductUnitOfMeasurement { get; private set; }

        public List<StorageLocation> StorageLocations { get; private set; }

        public Product(string produtctName, int productQuantity, bool productActive, ProductGroup productGroup, UnitOfMeasurement productUnitOfMeasurement)
        {
            ProdutctName = produtctName;
            ProductQuantity = productQuantity;
            ProductActive = productActive;
            ProductGroup = productGroup;
            ProductUnitOfMeasurement = productUnitOfMeasurement;
        }

        public Product(int productId, string produtctName, int productQuantity, bool productActive, ProductGroup productGroup, UnitOfMeasurement productUnitOfMeasurement) : this(produtctName, productQuantity, productActive, productGroup, productUnitOfMeasurement)
        {
            ProductId = productId;
        }
    }
}
