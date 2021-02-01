namespace CDE.Domain.Entities
{
    public class StorageLocation
    {
        public int StorageLocationId { get; private set; }
        public string Floor { get; private set; }
        public string Hall { get; private set; }
        public string Shelf { get; private set; }
        public string Bay { get; private set; }

        public int? IdProduct { get; set; }
        public virtual Product Product { get; set; }

        public StorageLocation(string floor, string hall, string shelf, string bay, int? idProduct)
        {
            Floor = floor;
            Hall = hall;
            Shelf = shelf;
            Bay = bay;
            IdProduct = idProduct;
        }

        public StorageLocation(int storageLocationId, string floor, string hall, string shelf, string bay, int? idProduct) : this(floor, hall, shelf, bay, idProduct)
        {
            StorageLocationId = storageLocationId;
        }
    }
}
