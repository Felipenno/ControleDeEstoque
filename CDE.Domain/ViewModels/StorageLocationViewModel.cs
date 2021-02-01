using CDE.Domain.Models;

namespace CDE.Domain.ViewModels
{
    public class StorageLocationViewModel
    {
        public int StorageLocationId { get; set; }
        public string Floor { get;  set; }
        public string Hall { get;  set; }
        public string Shelf { get;  set; }
        public string Bay { get;  set; }

        public int IdProduct { get; set; }
        public ProductModel Product { get; set; }

    }
}
