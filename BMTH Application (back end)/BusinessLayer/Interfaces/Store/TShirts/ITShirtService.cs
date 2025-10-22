using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Shirts;

namespace BusinessLayer.Interfaces.Store.TShirts
{
    public interface ITShirtService
    {
        public List<StoreItemOverview> GetTShirtsByGender(string? gender);
        public TShirt? GetShirtById(int? id);
    }
}
