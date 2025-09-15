using DataLayer.Dtos;

namespace DataLayer.Interfaces
{
    public interface ITShirtRepository
    {
        List<TShirtDto> GetAll();
    }
}
