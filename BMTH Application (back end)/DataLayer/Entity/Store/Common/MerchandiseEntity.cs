namespace DataLayer.Entity.Store.Common
{
    public abstract class MerchandiseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
