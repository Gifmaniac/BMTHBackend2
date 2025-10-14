using Contracts.Enums.Store;
using Contracts.Interfaces;
using DataLayer.Context;
using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;


namespace DataLayer.Repositories
{
    public class TShirtRepository : ITShirtRepository
    {
        private readonly StoreDbContext _context;

        public TShirtRepository(StoreDbContext context)
        {
            _context = context;
        }

        public List<TShirtModel> GetTShirtByGender(Genders? gender = null)
        {
            var query = new List<TShirtModel>();

            return query;
        }
    }
}
