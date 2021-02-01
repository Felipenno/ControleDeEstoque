using CDE.Domain.Enum;

namespace CDE.Domain.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProdutctName { get; set; }
        public int ProductQuantity { get; set; }
        public bool ProductActive { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public UnitOfMeasurement ProductUnitOfMeasurement { get; set; }
    }
}
