using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Products;

namespace BusinessLayer.Interfaces.Store.TShirts
{
    public interface ITShirtService
    {
        public List<StoreItemOverview> GetTShirtsByGender(string? gender);
        public Products? GetShirtById(int? id);
    }
}
