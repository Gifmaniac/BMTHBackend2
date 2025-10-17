using Contracts.Enums.Store;
using DataLayer.Context;

using DataLayer.Interfaces;
using DataLayer.Models.Store.TShirts;



namespace DataLayer.Repositories
{
    public class TShirtRepository : ITShirtRepository
    {
        private readonly AppDbContext _context;

        public TShirtRepository(AppDbContext context)
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
