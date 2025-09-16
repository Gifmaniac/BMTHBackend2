using DataLayer.Dtos.Store.TShirt;

namespace DataLayer.Interfaces
{
    public interface ITShirtRepository
    {
        List<TShirtDto> GetAll();
    }
}
