using CDE.Domain.Enum;
using CDE.Domain.Models;
using System.Collections.Generic;

namespace CDE.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get;  set; }
        public string ProdutctName { get;  set; }
        public int ProductQuantity { get;  set; }
        public bool ProductActive { get;  set; }
        public ProductGroup ProductGroup { get;  set; }
        public UnitOfMeasurement ProductUnitOfMeasurement { get;  set; }

        public List<StorageLocationModel> StorageLocations { get;  set; }
    }
}
