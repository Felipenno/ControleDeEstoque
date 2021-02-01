using CDE.Domain.Enum;

namespace CDE.Domain.ViewModels
{
    public class ProductCreateViewModel
    {
        public string ProdutctName { get; set; }
        public int ProductQuantity { get; set; }
        public bool ProductActive { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public UnitOfMeasurement ProductUnitOfMeasurement { get; set; }

        public ProductCreateViewModel(string produtctName, int productQuantity, bool productActive, ProductGroup productGroup, UnitOfMeasurement productUnitOfMeasurement)
        {
            ProdutctName = produtctName;
            ProductQuantity = productQuantity;
            ProductActive = productActive;
            ProductGroup = productGroup;
            ProductUnitOfMeasurement = productUnitOfMeasurement;
        }
    }
}
