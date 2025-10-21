using Contracts.Enums.Store;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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
            return _context.TShirts
                .AsNoTracking()
                .Include(t => t.Variants)
                .Where(t => t.Gender == gender)
                .ToList();
        }

        public TShirtModel GetById(int id)
        {
           return _context.TShirts
                .Include(t => t.Variants)
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);

        }
    }
}


