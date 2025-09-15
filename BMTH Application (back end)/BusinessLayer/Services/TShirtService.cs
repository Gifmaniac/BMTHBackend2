using DataLayer.Dtos;
using DataLayer.Repositories;

namespace BusinessLayer.Services
{
    public class TShirtService
    {
        private readonly TShirtRepository _repo;

        public TShirtService(TShirtRepository repo)
        {
            _repo = repo;
        }

        public List<TShirtDto> GetAllTShirts()
        {
            var shirtDto = _repo.MakeShirts();

        }

    }
}
