using DataLayer.Entities;

namespace BusinessLayer.Service
{
    public class TShirtService
    {
        private readonly TShirtService _repo;

        public TShirtService(TShirtService repo)
        {
            _repo = repo;
        }

        public List<TShirtEntity> GetAllTShirts()
        {
            return _repo.GetAllTShirts();
        }
    }
}
